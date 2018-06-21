---@class Button :UIComponent
---@field pos Position
---@field size Size
---@field zIndex number
---@field layer number
---@field bg string|number[]|Drawable
---@field children {draw}[]

local UIComponent = require('app.component.UIComponent');
---@type Button
local Button = require("app.component.UIComponent"):extend("Button")
local deep = require('lib.deep')


---@class BtnOpt
---@field x number
---@field y number
---@field zIndex number
---@field w number
---@field h number
---@field layer number
---@field bg string|number[]|Drawable
---@field content string|UIComponent|Drawable

---@return Panel
---@param btnOpt BtnOpt
function Button:new(btnOpt, ...)
    self.super.new(self)
    self.pos = { x = btnOpt.x, y = btnOpt.y }
    self.size = { w = btnOpt.w, h = btnOpt.h }
    self.bg = btnOpt.bg
    self.padding = { top = 0, left = 0, right = 0, bottom = 0 }
    self.zIndex = btnOpt.zIndex or 0
    self.layer = btnOpt.layer
    self.hitTest = true
    self.content = btnOpt.content
    for i, v in ipairs({ ... }) do
        self:addChild(v)
    end
end

function Button:onDraw(dt, x, y, z)
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
    if self.content then
        if type(self.content) == 'string' then
            if self.mouseOver then
                g.setColor(rgba('#222222'))
            else
                g.setColor(rgba('#289'))
            end
            --print(self.content)
            local t = g.newText(g.getFont(), self.content)
            t:setf(self.content, self.size.w - self.padding.left - self.padding.right, AlignMode.center);
            g.draw(t, x + self.padding.left, y + self.padding.top + (self.size.h - t:getHeight()) / 2)
        elseif self.content.is and self.content:is(UIComponent) then
            self.content:draw(dt, x + self.padding.left, y + self.padding.top, z)
        elseif self.content.typeOf and self.content:typeOf("Drawable") then
            g.draw(self.content, x + self.padding.left, y + self.padding.top)
        end
    end
    g.pop()
end

function Button:__tostring()
    return fmt("Panel(_id: %s, x: %s, y: %s, z: %z, w: %s, h:%s)", self._id, self.pos.x, self.pos.y, self.zIndex, self.size.w, self.size.h)
end

return Button