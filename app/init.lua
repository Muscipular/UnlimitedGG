local BASE = (...) .. '.'
require("lib.love")
require(BASE..'util')
require(BASE..'class')
require(BASE..'component')
return require(BASE..'app')
