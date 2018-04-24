;#DropDB LogisticEasyTest

#Application Logistic.Win
#Application Logistic.Web

*FillForm
 User Name = Admin
*Action Log On

#IfDef Logistic.Win

*Action About...
 
*Action OK

#EndIf

#IfDef Logistic.Web
*Action Navigation(My Details)
#EndIf
