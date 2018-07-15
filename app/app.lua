---@class Application: Base
---@field protected  _ctx table
---@field protected imgDir string
---@field protected fontDir string
---@field protected fontDefault Font
local Application = Base:extend()
local MenuScene = require('app.scene.menu')
local Gamestate = require "lib.hump.gamestate"
local deep = require('lib.deep')
---@type nuklear
local nk = require('nuklear')
---@type Registry
local Signal = require('lib.hump.signal')

function Application:new()
    local graphics = love.graphics
    graphics.setDefaultFilter("nearest", "nearest")
    self._ctx = {}
    self.runTime = 0;
    self.imgDir = "/image/"
    self.fontDir = "/font/"
    self.fontDefaultPath = self.fontDir .. "sh.otf"
    self.fontDefault = graphics.newFont(self.fontDefaultPath, 14)
    self.font14Px = self.fontDefault
    self.font32Px = graphics.newFont(self.fontDefaultPath, 32);
    self.font24Px = graphics.newFont(self.fontDefaultPath, 24);
    self.font18Px = graphics.newFont(self.fontDefaultPath, 18);
    self.font12Px = graphics.newFont(self.fontDefaultPath, 12);
    graphics.setFont(self.fontDefault)
    graphics.setColor({ 0, 0, 0 })
    graphics.setBackgroundColor(rgba("#FFFFFF"))
    self:registerEvents()
    --self:addChild(MainScene());
end

function Application:start()
    Gamestate.switch(MenuScene())
end

function Application:registerEvents()
    local all_callbacks = { 'draw', 'update' }
    for k in pairs(love.handlers) do
        all_callbacks[#all_callbacks + 1] = k
    end
    --print(unpack(all_callbacks))
    for _, f in ipairs(all_callbacks) do
        if not self[f] then
            self[f] = function(self, ...)
            end
        end
        print('register event:', f)
        love[f] = function(...)
            Gamestate[f](...)
            return self[f](self, ...)
        end
    end
    Signal.register('sceneChange', function(s, ...)
        if type(s) == 'string' then
            s = require('app.scene.' + s)();
        end
        Gamestate:switch(s, ...);
    end)
    Signal.register('scenePush', function(s, ...)
        if type(s) == 'string' then
            s = require('app.scene.' .. s)();
        end
        Gamestate.push(s, ...);
    end)
    Signal.register('scenePop', function(...)
        Gamestate.pop(...);
    end)
end

function Application:update(dt)
    --self.super.update(self, dt);
    self.runTime = self.runTime + dt;
end

function Application:draw()
    deep.execute()
    --self.super.draw(self);
    local h = love.graphics.getHeight();
    love.graphics.print("FPS: " .. love.timer.getFPS(), 0, h - 20 * 2)
    local state = love.graphics.getStats()
    love.graphics.print("DrawCall: " .. state.drawcalls, 0, h - 20)
    --love.graphics.print("draw call: " .. state.canvasswitches, 0, 20)
end

return Application