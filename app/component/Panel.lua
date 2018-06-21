---@class Panel :Base
---@field pos Position
---@field size Size
---@field zIndex number
---@field layer number
---@field bg string|number[]|Drawable
---@field children {draw}[]

local UIComponent = require("app.component.UIComponent")

---@type Panel
local Panel = UIComponent:extend("Panel")
local deep = require('lib.deep')

---@return Panel
function Panel:new(layer, x, y, w, h, z, background, ...)
    UIComponent.new(self)
    self.pos = { x = x, y = y }
    self.size = { w = w, h = h }
    self.bg = background
    self.zIndex = z or 0
    --print(#self.children)
    self.layer = layer
    self.hitTest = true
    for i, v in ipairs({ ... }) do
        self:addChild(v)
    end
end

function Panel:addChildren(c)
    table.insert(self.children, c)
end

function Panel:onDraw(dt, x, y, z)
    if self.alpha <= 0 then
        return
    end
    local bg = self.bg
    if not bg then
        return
    end
    local g = love.graphics
    g.push(StackType.all)
    if type(bg) == 'string' then
        g.setColor(rgba(bg))
        g.rectangle(DrawMode.fill, self.pos.x + x, self.pos.y + y, self.size.w, self.size.h)
    elseif type(bg) == 'table' and (#bg == 3 or #bg == 4) then
        g.setColor(bg)
        g.rectangle(DrawMode.fill, self.pos.x + x, self.pos.y + y, self.size.w, self.size.h)
    else
        local w, h = unpack(self.size)
        if bg.getWidth then
            w = bg.getWidth()
        end
        if bg.getHeight then
            h = bg.getHeight()
        end
        g.draw(bg, self.pos.x + x, self.pos.y + y, 0, w / self.size.w, h / self.size.h)
    end
    if self.mouseOver then
        --print(tostring(self), "mouse over", application.runTime)
    end
    g.pop()
end

function Panel:__tostring()
    return fmt("Panel(_id: %s, x: %s, y: %s, z: %s, w: %s, h:%s)", self._id, self.pos.x, self.pos.y, self.zIndex, self.size.w, self.size.h)
end

return Panel