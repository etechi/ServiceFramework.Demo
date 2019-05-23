后端服务器：
1. 安装dotnet core
https://www.microsoft.com/net/download/windows

2. 修改 backend/appsettings.json 中的连接字符串
修改 服务器，数据库(比如 kdl-site)，用户，密码

3. 在sqlserver中新建一个空数据库 比如 kdl-site

4. 执行StartSite.bat启动站点

5. 访问下面连接初始化服务：
 http://kdltest.zx-emc.com/
 http://kdltest.zx-emc.com/api/servicefeaturecontrol/init/service
 成功后显示 "OK"

6. 访问下面连接初始化数据：
 http://kdltest.zx-emc.com/api/servicefeaturecontrol/init/data?host=kdltest.zx-emc.com&ext-ident-postfix=50
 成功后显示 "OK"

7. 导入数据
疾病数据
http://kdltest.zx-emc.com/api/servicefeaturecontrol/init/import_disease
药品
http://kdltest.zx-emc.com/api/servicefeaturecontrol/init/import_pharmacon_db
http://kdltest.zx-emc.com/api/servicefeaturecontrol/init/import_pharmacon_file


web端
1. 控制台转至 项目目录:
Browser\kdlclient

2. 安装依赖包：
npm install

如果速度慢，可以使用npm淘宝镜像
http://npm.taobao.org/
npm config set registry http://registry.npm.taobao.org/

安装结尾可能出错，可以忽略

3. 启动webpack 服务器
npm run dev

4. 访问http://localhost:8080 可以看到网站

5. 访问http://localhost:8080/webpack-dev-server/ 可以跟踪编辑

关于API调用
使用webpack会将针对http://localhost:8080/api/xxxx的访问重定向到后端服务器

API调用参考 \Browser\kdlclient\src\components\Docs\ 下的组件


其他：
http://localhost:5000/api/servicemetadata/html  api文档
http://localhost:5000/api/servicemetadata/java?commonimports=xxxx&packagepath=a.b.c&all=false  导出java api客户端
http://localhost:5000/api/servicemetadata/ios?commonimports=xxxx&baseservice=a.b.c&all=false  导出ios api客户端
http://localhost:5000/api/servicemetadata/tsd?apiname=KDLApi  导出tsd文件，用于vs code语法提示
http://localhost:5000/api/servicemetadata/javascript?apiname=KDLApi  导出js客户端api支持


