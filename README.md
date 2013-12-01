Uteis
=====

##Xml Documentation Handle


Essa classe tem por finalidade acessar o arquivo de comentários XML no .NET. Esses comentários são criados quando se comenta utilizando-se de três barras "///".


###Uso Padrão

O método principal utilizado é GetXmlDocumentationClass. Ele pode receber 2, 3 ou 4 parâmetros.



'
//Inicializa o objeto
XmlDocumentation objXmlDocumentation = new XmlDocumentation();

//Cria um enum do tipo IDSTRING, que existe dentro de XmlDocumentation. As opções sao:
//IDSTRING.NAMESPACE
//IDSTRING.CLASS
//IDSTRING.FIELD
//IDSTRING.PROPERTY
//IDSTRING.METHOD
//IDSTRING.EVENT
objXmlDocumentation.IDSTRING ID_STRING = objXmlDocumentation.IDSTRING.CLASS;

//Recupera o struct Documentation, onde você pode recuperar:
//ID_STRING -
//members
objXmlDocumentation.Documentation objDocumentation = 
  GetXmlDocumentationClass("SeuNamespace.SuaClasse", ID_STRING);
  '
  



