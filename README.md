Uteis
=====

##Xml Documentation Handle


Essa classe tem por finalidade acessar o arquivo de comentários XML no .NET. Esses comentários são criados quando se comenta utilizando-se de três barras "///".


###Uso Padrão

O método principal utilizado é GetXmlDocumentationClass. Ele pode receber 2, 3 ou 4 parâmetros.

```csharp

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
```
  
###Outros usos

O método possui mais dois outros parâmetros. O primeiro deles define se a busca será feita no namespace inteiro, ou seja, apenas na classe em questão (comportamento padrão - true) ou em todas as classes do namespace.

Exemplo de uso:

```CSHARP

//Nesse caso a busca será feita em todas as classes do namespace

XmlDocumentation objXmlDocumentation = new XmlDocumentation();
objXmlDocumentation.IDSTRING ID_STRING = objXmlDocumentation.IDSTRING.CLASS;
objXmlDocumentation.Documentation objDocumentation =  
  GetXmlDocumentationClass("SeuNamespace.SuaClasse", ID_STRING, false);
  
```


