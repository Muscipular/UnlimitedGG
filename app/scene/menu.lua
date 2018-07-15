---@type nuklear
local nk = require 'nuklear'
local Component = require('app.component.base')
local helper = require('app.scene.helper')
---@type Registry
local Signal = require("lib.hump.signal")

---@class MenuScene : Component
local MenuScene = Component:extend()

function MenuScene:new()
    self.super.new(self)
end

function MenuScene:enter()
    nk.init();
end

function MenuScene:resume()
    nk.init();
end

function MenuScene:leave()
    nk.shutdown();
end

function MenuScene:draw()
    nk.draw();
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
        nk.styleSetFont(application.font24Px)
        nk.button("开始")
        nk.styleSetFont(love.graphics.getFont())
        if nk.widgetIsHovered() then
            love.mouse.setCursor(love.mouse.getSystemCursor(CursorType.hand))
        else
            love.mouse.setCursor(love.mouse.getSystemCursor(CursorType.arrow))
        end
        if nk.widgetHasMouseReleased(NK_MouseButtonType.left) then
            Signal.emit('scenePush', 'main')
        end
        nk.layoutSpaceEnd()
        nk.windowEnd()
    end

    nk.frameEnd()
end
helper.registerNKCallback(MenuScene)

return MenuScene