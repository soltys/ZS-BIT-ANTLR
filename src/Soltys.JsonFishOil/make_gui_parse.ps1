Remove-Item *.java
Remove-Item *.class
Remove-Item *.tokens
Remove-Item *.interp
antlr  ..\JsonFishOil.g4 -o JAVAOUT
javac JsonFishOil*.java
grun JsonFishOil fishOil ..\..\make_arr.txt -gui
