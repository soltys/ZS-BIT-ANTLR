grammar JsonFishOil;

fishOil
    : objMake    
    | arrMake
    | accessChain    
    ;
arrMake
    : '[' jsonValue (',' jsonValue)* ']'
    ;

objMake
    : '{' propertyExpr (',' propertyExpr)* '}'
    ;

propertyExpr
    : NAME ':' jsonValue
    ;

jsonValue
    : STRING
    | NUMBER
    | accessChain
    | objMake
    | arrMake
    ;

accessChain
    : access accessChain?
    ;

access : '.'  NAME '[' NUMBER ']'
       | '.'  NAME
       | '.' '[' NUMBER ']'
       | '.' 
       ;

WS
    : [ \t\u000C\r\n]+ -> skip
    ;


NUMBER
   : '-'? Integer ('.' [0-9] +)? EXP?
   ;


NAME
    : [a-zA-Z_][a-zA-Z_0-9]*
    ;


STRING
: '"' (ESC | SAFECODEPOINT)* '"'
;


fragment ESC
   : '\\' (["\\/bfnrt] | UNICODE)
   ;
fragment UNICODE
   : 'u' HEX HEX HEX HEX
   ;
fragment HEX
   : [0-9a-fA-F]
   ;
fragment SAFECODEPOINT
   : ~ ["\\\u0000-\u001F]
   ;

   




fragment Integer
   : '0' | [1-9] [0-9]*
   ;

// no leading zeros

fragment EXP
   : [Ee] [+\-]? Integer
   ;
