--local nk = require 'nuklear'
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
    self.world = tiny.world(
            --require('app.systems.ChildrenSystem')(),
            require('app.systems.HitTestSystem')(Layers.fg),
            --require('app.systems.UISystem')(Layers.bg),
            require('app.systems.UISystem')(Layers.fg)
    )
    local world = self.world
    world:add(Panel(Layers.fg, 100, 100, 200, 200, 1, '#efcce1', Button({
        x = 2,
        y = 2,
        w = 100,
        h = 50,
        content = "1234",
        bg = "#fff",
        layer = Layers.fg
    })))
    print(world:getSystemCount(), world:getEntityCount())
end

function MenuScene:draw()
    --print('MenuScene:draw')
    self.world:update(love.timer.getDelta())
    deep.execute()
end

function MenuScene:update(dt)
    --print('MenuScene:update')
    self.world:update(dt, updateFilter)
end

--function MenuScene:keypressed(key, scancode, isrepeat)
--    nk.keypressed(key, scancode, isrepeat)
--end
--
--function MenuScene:keyreleased(key, scancode)
--    nk.keyreleased(key, scancode)
--end
--
--function MenuScene:mousepressed(x, y, button, istouch)
--    nk.mousepressed(x, y, button, istouch)
--end
--
--function MenuScene:mousereleased(x, y, button, istouch)
--    nk.mousereleased(x, y, button, istouch)
--end
--
--function MenuScene:mousemoved(x, y, dx, dy, istouch)
--    nk.mousemoved(x, y, dx, dy, istouch)
--end
--
--function MenuScene:textinput(text)
--    nk.textinput(text)
--end
--
--function MenuScene:wheelmoved(x, y)
--    nk.wheelmoved(x, y)
--end

return MenuScene