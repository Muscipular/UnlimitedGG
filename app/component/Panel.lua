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

---@class PanelState
---@field bg string|number[]|Drawable
---@field color string|number[]
---@field border number
---@field borderColor string|number[]


---@class PanelOpt:PanelState
---@field x number
---@field y number
---@field zIndex number
---@field w number
---@field h number
---@field layer number
---@field radius number
--@field states table<string, PanelState>

---@return Panel
---@param opt PanelOpt
function Panel:new(opt, ...)
    UIComponent.new(self)
    self.pos = { x = opt.x or 0, y = opt.y or 0 }
    self.size = { w = opt.w or 0, h = opt.h or 0 }
    self.zIndex = opt.zIndex or 0
    self.layer = opt.layer
    self.hitTest = true
    self.bg = opt.bg
    self.border = opt.border
    self.borderColor = rgba(opt.borderColor or "#fff")
    self.radius = opt.radius or 0
    for i, v in ipairs({ ... }) do
        self:addChild(v)
    end
end

function Panel:onDraw(dt, x, y, z)
    if self.alpha <= 0 then
        return
    end
    local bg = self.bg
    local g = love.graphics
    if bg then
        g.push(StackType.all)
        if type(bg) == 'string' then
            g.setColor(rgba(bg))
            g.rectangle(DrawMode.fill, self.pos.x + x, self.pos.y + y, self.size.w, self.size.h, self.radius, self.radius, 2)
        elseif type(bg) == 'table' and (#bg == 3 or #bg == 4) then
            g.setColor(bg)
            g.rectangle(DrawMode.fill, self.pos.x + x, self.pos.y + y, self.size.w, self.size.h, self.radius, self.radius, 2)
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
    end
    if self.border then
        g.setColor(self.borderColor)
        g.rectangle(DrawMode.line, self.pos.x + x, self.pos.y + y, self.size.w - self.border, self.size.h - self.border, self.radius, self.radius, self.border)
    end
    g.pop()
end

function Panel:__tostring()
    return fmt("Panel(_id: %s, x: %s, y: %s, z: %s, w: %s, h:%s)", self._id, self.pos.x, self.pos.y, self.zIndex, self.size.w, self.size.h)
end

return Panel