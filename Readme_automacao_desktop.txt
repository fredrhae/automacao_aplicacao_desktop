############  Pré-requisitos para rodar a aplicação:  ############

- Ter certeza que os pacotes nuget abaixo estão instalados no projeto:
	* log4net 2.0.5
	* Selenium Webdriver
	* Selenium Webdriver Support Classes
	
- Ter o Visual Studio 2013 ou mais novo
- Ter o arquivo Winium.Desktop.Driver.exe rodando na porta default 9999
	* O winium é a versão do Selenium para windows e esse é o servidor do desktop que executará as ações feitas na automação.
	* O arquivo pode ser baixado no seguinte link: https://github.com/2gis/Winium.Desktop/releases/download/v1.5.0/Winium.Desktop.Driver.zip
- Ter a pasta C:/Projeto criada no disco, lá serão armazenados o log e o printscreen
	* Além da pasta estar criada ela precisa ter o arquivo texto com dados fakes de entrada que serão usadas na automação. O nome do arquivo
	deve ser "automacao_desktop_texto_entrada.txt".

###########   Pontos a serem destacados do código   #############

- Para facilitar a geração de logs, está integrado com o projeto o log4net, a biblioteca de geração de log mais utilizada nos projetos em .Net. Ela é bastante versátil e fácil de utilizar, podendo ajudar em um processo de teste mais completo com várias funcionalidades que possam ser adicionadas neste projeto. Atualmente, ele está configurado para logar as saídas no console e em um arquivo texto na pasta C:/Projeto.

- Deve-se levar em consideração que o projeto está configurado para utilizar o Word 2010 que está instalado no meu computador. Portanto o nome das classes, IDs dos elementos usados na automatização seguem o padrão do meu computador. Para descobrir tais nomes e elementos eu utilizei a ferramenta Inspect.exe que vem instalado junto com o Visual Studio. Ela fica no seguinte path: "C:\Program Files (x86)\Windows Kits\8.1\bin\x86\inspect.exe"

