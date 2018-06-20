---@class Panel :Base
---@field pos Position
---@field size Size
---@field zIndex number
---@field layer number
---@field bg string|number[]|Drawable
---@field children {draw}[]

---@type Panel
local Panel = Base:extend()
local deep = require('lib.deep')

function Panel:new(layer, x, y, w, h, z, background, ...)
    self.pos = { x = x, y = y }
    self.size = { w = w, h = h }
    self.bg = background
    self.zIndex = z or 0
    self.children = { ... }
    --print(#self.children)
    self.layer = layer
    self.alpha = 1
    self.hitTest = true
end

function Panel:drawPanel(dt)
    deep.queue(self.layer * 100 + self.zIndex, function(e)
        e:_draw()
    end, self);
    for i = 1, #self.children do
        local x, y = self.pos.x, self.pos.y
        deep.queue(self.layer * 100 + self.zIndex + (self.children[i].zIndex or 0), function(e, x, y)
            --print(e.id)
            e:draw(x, y)
        end, self.children[i], x, y)
    end
end

function Panel:addChildren(c)
    table.insert(self.children, c)
end

function Panel:_draw()
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
        g.rectangle(DrawMode.fill, self.pos.x, self.pos.y, self.size.w, self.size.h)
    elseif type(bg) == 'table' and (#bg == 3 or #bg == 4) then
        g.setColor(bg)
        g.rectangle(DrawMode.fill, self.pos.x, self.pos.y, self.size.w, self.size.h)
    else
        local w, h = unpack(self.size)
        if bg.getWidth then
            w = bg.getWidth()
        end
        if bg.getHeight then
            h = bg.getHeight()
        end
        g.draw(bg, x, y, 0, w / self.size.w, h / self.size.h)
    end
    --g.setColor(rgba('#f00'))
    --if self.mouseOver then
    --    g.print(self._id .."Mouse Over", self. pos.x, self. pos.y + 20)
    --else
    --    g.print(self._id, self. pos.x, self. pos.y + 20)
    --end
    g.pop()
end

function Panel:__tostring()
    return string.format("Panel(_id: %s, x: %s, y: %s, z: %z, w: %s, h:%s)", self._id, self.pos.x, self.pos.y, self.zIndex, self.size.w, self.size.h)
end

return Panel