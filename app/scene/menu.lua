---@type nuklear
local nk = require 'nuklear'
local Component = require('app.component.base')
local tiny = require('lib.tiny')
local drawFilter = tiny.requireAll('isDrawSystem')
local updateFilter = tiny.rejectAny('isDrawSystem')

local Panel = require("app.component.Panel")
local Button = require("app.component.Button")

---@class MenuScene :Component
---@field world ECS_World
local MenuScene = Component:extend()

function MenuScene:new()
    self.super.new(self)
end

function MenuScene:enter()
    nk.init()
end

function MenuScene:draw()
    nk.draw()
    --deep.execute()
end

function MenuScene:update(dt)
    nk.frameBegin()

    local color = NK_ColorTable()
    color.window = '#efefef'
    color.text = "#ffffff"
    color.button = "#777777"
    color[NK_ColorTableFields.buttonActive] = "#333333"
    color[NK_ColorTableFields.buttonHover] = "#565656"
    nk.styleLoadColors(color)
    if nk.windowBegin("Test", 0, 0, love.graphics.getWidth(), love.graphics.getHeight()) then
        nk.layoutSpaceBegin(NK_Layout_Mode.static, love.graphics.getHeight(), 4)
        nk.layoutSpacePush(200, 250, 400, 50)
        nk.button("开始")
        if nk.widgetIsHovered() then
            love.mouse.setCursor(love.mouse.getSystemCursor(CursorType.hand))
        else
            love.mouse.setCursor(love.mouse.getSystemCursor(CursorType.arrow))
        end
        nk.layoutSpaceEnd()
    end
    nk.windowEnd()
    nk.frameEnd()
    --print('MenuScene:update')
    --self.world:update(dt, updateFilter)
end

function MenuScene:keypressed(key, scancode, isrepeat)
    nk.keypressed(key, scancode, isrepeat)
end

function MenuScene:keyreleased(key, scancode)
    nk.keyreleased(key, scancode)
end

function MenuScene:mousepressed(x, y, button, istouch)
    nk.mousepressed(x, y, button, istouch)
end

function MenuScene:mousereleased(x, y, button, istouch)
    nk.mousereleased(x, y, button, istouch)
end

function MenuScene:mousemoved(x, y, dx, dy, istouch)
    nk.mousemoved(x, y, dx, dy, istouch)
end

function MenuScene:textinput(text)
    nk.textinput(text)
end

function MenuScene:wheelmoved(x, y)
    nk.wheelmoved(x, y)
end

return MenuScene