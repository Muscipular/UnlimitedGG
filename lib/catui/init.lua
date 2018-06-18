--[[
The MIT License (MIT)

Copyright (c) 2016 WilhanTian  田伟汉

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
]]--
local BASE = 'lib.'

utf8 = require("utf8")
class = require(BASE .. "catui.libs.30log")

require(BASE .. "catui.Core.UIDefine")

theme = require(BASE .. "catui.UITheme")

point = require(BASE .. "catui.Utils.Utils")
Rect = require(BASE .. "catui.Core.Rect")
UIEvent = require(BASE .. "catui.Core.UIEvent")
UIControl = require(BASE .. "catui.Core.UIControl")
UIRoot = require(BASE .. "catui.Core.UIRoot")
UIManager = require(BASE .. "catui.Core.UIManager")
UILabel = require(BASE .. "catui.Control.UILabel")
UIButton = require(BASE .. "catui.Control.UIButton")
UIImage = require(BASE .. "catui.Control.UIImage")
UIScrollBar = require(BASE .. "catui.Control.UIScrollBar")
UIContent = require(BASE .. "catui.Control.UIContent")
UICheckBox = require(BASE .. "catui.Control.UICheckBox")
UIProgressBar = require(BASE .. "catui.Control.UIProgressBar")
UIEditText = require(BASE .. "catui.Control.UIEditText")
