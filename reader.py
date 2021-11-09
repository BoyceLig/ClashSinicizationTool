import web.json;
import fsys.stream;

namespace fsys.asar;

class reader{
	ctor(path){{
		
		if(#path<0x410/*_MAX_PATH_U8*/){
			if( ..io.exist(path) ){
				this.file = ..fsys.stream(path,"r+");
			}
			elseif(..io.localpath(path)){
				var str = ..string.load(path);
				if(str) this.file = ..fsys.stream(str);
			}
			else {
				this.file = ..fsys.stream(path);
			}
			
		}
		else {
			this.file = ..fsys.stream(path);
		} 
		 
		if(!this.file) return null,"打开文件失败";
		this.unpackedPath = path + ".unpacked";
		
		var h  = header();
		
		if(this.file.read(h)) { 
			var json = this.file.read(h.headerJson.size);
			if(json) {
				this.header = h;
				this.info = ..web.json.tryParse(json); 
			} 
		}
		
		if(!this.info) {
			this.file.close();
			return null,"文件格式错误";
		}
		this.rawInfo = ..table.clone(this.info);
		
		this.files = {};
		var headerSize =  h.headerSize.size + 8/*..raw.sizeof(h.headerSize)*/;
		var size = 0;
		var enumInfo;
		enumInfo = function(info,parent){  
			for(k,v in info.files){  
				v.path = #parent? parent +"\"+ k : k;
				..table.push(this.files,v);
				
				if( v.files ){
					enumInfo(v,v.path); 
				}
				elseif(v.offset!=null){
					v.offset = v.offset + headerSize; 
					size = size + v.offset;
				}  
			}
		}
		this.totalSize = this.file.size() - headerSize;
		this.headerSize = headerSize;
		enumInfo(this.info);
		
		..table.gc(this,"close");
	}}; 
	_enumInfo = function(proc,info){ 
		
		var filepath;
		for(k,v in info.files){ 
			if( v.files ){
					this._enumInfo(proc,v);
					proc(k,v.path)
			}
			else {
				if(v.offset)this.file.seek("set",v.offset);
				proc(k,v.path,v.offset,v.size,v.executable,v.unpacked)	
			} 
		}
	}
	enum = function(proc){ 
		return this._enumInfo(proc,this.info); 
	}
	treeData = function(){
		var treeData = {}; 
		var enumInfo;
		enumInfo = function(info,td,parent){  
			for(k,v in info.files){    
				if( v.files ){
					var children = {text = k;path = v.path;unpacked = v.unpacked;}
					..table.push(td,children); 
					enumInfo(v,children,v.path); 
				}
				else {
					..table.push(td,{text = k;path = v.path;size = v.size;unpacked = v.unpacked; }); 
				}  
			}
		} 
		enumInfo(this.info,treeData);
		return treeData; 
	};
	eachFile = function(){
		var len,i,v = #this.files,0;
		return function(){
			i++;
			v = this.files[i];
			
			if(v) {
				if(v.offset)this.file.seek("set",v.offset);
				return v.path,v.size,v.offset,v.executable,v.unpacked;
			};
		} 
	};
	find = function(info,path){
		var t =  ..string.split(path,"\/");
		
		var f = info;
		for(i=1;#t;1){
			if!(#t[i]) continue;
			
			if(!f.files) {
				if(i==#t)break;
				return;
			};
			f = f.files[t[i]]
		}
		return f;
		
	};
	seek = function(path){
		var t =  ..string.split(path,"\/");
		
		var f = this.find(this.info,path); 
		if(f ? f.offset){
			this.file.seek("set",f.offset);
			if( f.offset) return f.offset,f.size;
		}
		
	};
	replaceText = function(path,data){
		if(type(path)!="string") return null,"请指定相对路径";
		if(!data)  return null,"请指定要替换的数据,清空请输入空字符串";
		return this.replace(path,..string.crlf(data,true));
	};
	replace = function(path,data){
		var t =  ..string.split(path,"\/");
		
		var rawInfo = ..table.clone(this.rawInfo);
		var f = this.find(rawInfo,path);   
		
		if(f ? f.offset){
			this.file.seek("set",f.offset+this.headerSize);
			if(#data < f.size ) f.size = #data;
			elseif (#data > f.size ) return null,"数据不能超出原来的存储长度,请检查是不是多了回车符等字节";
			
			var json = ..web.json.stringify(rawInfo);
			if(#json> (this.header.headerJson.pickleOjectSize-4) )
				return null,"写入asar文件头错误";
				
			if( f.size ){
				this.file.write(data,f.size);
			}
			this.header.headerJson.size = #json
			this.file.seek("set")
			this.file.write(this.header);
			this.file.write(json); 
			this.rawInfo = rawInfo;
			
			var f2 = this.find(this.info,path); 
			if(f2 ? f2.offset){ 
				f2.size = f.size;
				return true;
			}
		} 
		return null,"写入asar文件错误";
		
	};
	read = function(...){
		return this.file.read(...);
	};
	readTo = function(...){
		return this.file.readTo(...);
	};
	readFile = function(path){
		var offset,size = this.seek(path);
		if(offset===null){
			var f = this.find(this.info,path); 
			if(f ? f.unpacked ){
				var src = ..io.joinpath(this.unpackedPath,path)
				if(..io.exist(src)){
					return ..string.load(src);
				}
			}
			return;
		}
		
		if(size) return this.file.read(size);
	}; 
	eachReadBuffer = function(buf,size){ 
		if(type(size)==type.string) {
			return this.eachReadBuffer(buf,rget(2,this.seek(size))); 
		}
		
		if(!size) return function(){};
		var bufSize,readSize = #buf;
		
		return function(){
			if(bufSize>size)bufSize=size;
			readSize = this.file.readBuffer(buf,bufSize);
			if(readSize){
				size = size - readSize;
				return readSize;
			}
		}
	};
	eachUnpack = function(extractDir,buf){
		if( type(extractDir)!= type.string ) error("必须使用参数@1指定解压目录",2);
		
		if(!buf) buf = ..raw.buffer(0xA00000);
		var nextFile = this.eachFile();
		var pathFile,sizeFile,offsetFile,executable,unpacked = nextFile()
		while(pathFile &&(offsetFile===null)){
			var path = ..io.joinpath(extractDir,pathFile);
			if(unpacked){
				var src = ..io.joinpath(this.unpackedPath,pathFile)
				if(..io.exist(src)){
					var bin = ..string.loadBuffer(src);
					if(#bin){
						..string.save(path,bin)
					}
				}
			}
			elseif(!sizeFile)..io.createDir(path);
			
			pathFile,sizeFile,offsetFile,executable,unpacked = nextFile();
		}
		
		if(!pathFile){return function(){}};
		var nextBlock = this.eachReadBuffer(buf,sizeFile); 
		
		var path = ..io.joinpath(extractDir,pathFile);
		if(!..io.createDir(..io.splitpath(path).dir ) ) error('创建文件目录失败\n' + ..io.splitpath(path).dir ,2);
		
		var outfile = ..io.open(path,"w+b")
		if(!outfile) error('创建文件失败\n' + path ,2);
		
		var totalSize = this.totalSize;
		var totalReadSize = 0;
		
		var next ;
		next = function(){
			var readSize = nextBlock(); 
			if( readSize ){
				totalReadSize= totalReadSize + readSize;
				outfile.writeBuffer(buf,readSize);
				return pathFile,totalReadSize,totalReadSize/totalSize;
			};
			outfile.close();	
			
			pathFile,sizeFile,offsetFile,executable,unpacked = nextFile();
			while(pathFile &&(offsetFile===null)){
				var path = ..io.joinpath(extractDir,pathFile);
				if(unpacked){
					var src = ..io.joinpath(this.unpackedPath,pathFile)
					if(..io.exist(src)){
						var bin = ..string.loadBuffer(src);
						if(#bin){
							..string.save(path,bin)
						}
					} 
				}
				elseif(!sizeFile)..io.createDir(path);
				
				pathFile,sizeFile,offsetFile,executable,unpacked = nextFile();
			}
			
			if(pathFile){
				nextBlock = this.eachReadBuffer(buf,sizeFile);
				
				var path = ..io.joinpath(extractDir,pathFile);
				if(!..io.createDir(..io.splitpath(path).dir ) ) error('创建文件目录失败\n' + ..io.splitpath(path).dir ,2); 
				outfile = ..io.open(path,"w+b")
				if(!outfile) error('创建文件失败\n' + path ,2);
		
				return next();
			}
		}
		return next;
	};
	unpack = function(extractDir){
		for(readSize in this.eachUnpack(extractDir) ){}
	};
	close = function(){
		this.file.close();
	};
}

namespace reader{
	
	class header {
		struct headerSize = {
			INT pickleOjectSize = 4;
			INT size;	
		}
		struct headerJson = {
			INT pickleOjectSize;
			INT size;
		}
	}
}

/**intellisense()
fsys.asar = asar是electron里的一种打包文件格式
fsys.asar.reader = asar是electron里的一种打包文件格式
fsys.asar.reader = asar格式文件解析器\n支持内存文件,资源文件,硬盘文件等\n支持解析asar格式文件，直接加载到treeview控件，单独提取文件，\n提取全部文件并获取展开进度，支持直接编辑文件数据，\n替换文件内容(不用解包再打包)
fsys.asar.reader(__) = 创建asar格式文件解析器,\n参数中输入asar文件路径
fsys.asar.reader() = !fsys_unasar_reader.
end intellisense**/

/**intellisense(!fsys_unasar_reader)
this.header = 文件头,fsys.unasar.header结构体
info = 文件系统信息,这是一个树形结构的表
files = 文件信息列表,这是一个数组
totalSize = asar中所有文件的大小,不包含asar文件头大小
headerSize = asar文件头大	
enum = @.enum(\n	function(fileName,path,offset,size,executable,unpacked){\n		__/*fileName:文件名\npath:包含上层目录的相对路径\noffset:如果是包内文刚表示偏移位置,并已移动文件指针到这里\nsize:文件大小\nexecutable:是否可执行文件\nunpacked 是否外部 unpacked 目录下的文件*/\n	}\n)
seek(__) = 参数中指定文件的相对路径,\n移动文件指针到此文件在asar文件中的开始位置\n失败返回 null
read(__) = 这个函数的参数与fsys.stream参数的read函数一样用法,\n建议在这里指定要读取的长度\n不指定长度读取一行，但不可以指定负数\n可以指定结构体
readTo(__) =  读取直到以参数指定的字符串结束,不包含束字符串\n这个函数会一直向后读,而不考虑是不是越过了当前的文件块
readFile(__) = 参数中指定文件的相对路径,\n读取并返回文件的全部数据,返回值为字符串值
eachReadBuffer(缓冲区,文件路径) = @for readSize in ??.eachReadBuffer(缓冲区对象,"要读取取的文件相对路径") {
	__/*迭代器的第一个参数应当是缓冲区\n第二个参数可选指定要读取的文件相对路径,也可以指定要读取的大小\n迭代变量 readSize 表示本次读取的长度*/
}
eachFile = @for path,size,offset,executable,unpacked in ??.eachFile(){
	__/*path:包含上层目录的相对路径\nsize:文件大小,已自动移动文件指针到文件所在的偏移位置\noffset: 文件偏移位置,offset为null则为目录或 unpacked 文件,\nexecutable:是否可执行文件\nunpacked 为true的文件未包含在asar文件内*/	
}
eachUnpack(解压目录,缓冲区) = @for path,size,progress in ??.eachUnpack("/ExtractDir") {
	__/*迭代器的第一个参数应指下要解压的目录\n可选使用第二个参数定定缓冲区对象\npath为当前正在处理的文件路径,size为已解包总大小,\nprogress是使用小数表示的进度,1为已完成\n*/
}
unpack(.(解压目录) = 直接解压所有文件到指定目录下\n如果要获取解压的进度,建议使用eachUnpack迭代器
treeData() = 返回可以直接加载到treeview视图的数据表
replace(.("文件相对路径",替换数据) = 写入替换数据长度不能大于原数据长度
replaceText(.("文件相对路径",替换数据)  = 替换文本并移除回车使用'\n'单换行
end intellisense**/