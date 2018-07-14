---@type nuklear
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
end

function MenuScene:draw()
end

function MenuScene:update(dt)
end

return MenuScene