local BASE = (...) .. '.'
require("lib.love")
JSON = require("lib.json")
require(BASE .. 'util')
require(BASE .. 'class')

_G.Layers = {
    bg = 0,
    fg = 1,
    mask = 2,
}

deep = require('lib.deep')

--require(BASE..'component')
return require(BASE .. 'app')
