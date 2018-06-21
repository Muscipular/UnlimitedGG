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


---@class BtnState
---@field bg string|number[]|Drawable
---@field color string|number[]
---@field border number
---@field borderColor string|number[]

---@class BtnOpt:BtnState
---@field x number
---@field y number
---@field zIndex number
---@field w number
---@field h number
---@field layer number
---@field radius number
---@field content string|UIComponent|Drawable
---@field states table<string, BtnState>

---@return Panel
---@param btnOpt BtnOpt
function Button:new(btnOpt, ...)
    UIComponent.new(self)
    self.pos = { x = btnOpt.x, y = btnOpt.y }
    self.size = { w = btnOpt.w, h = btnOpt.h }
    self.padding = { top = 0, left = 0, right = 0, bottom = 0 }
    self.zIndex = btnOpt.zIndex or 0
    self.layer = btnOpt.layer
    self.radius = btnOpt.radius or 0
    self.bg = btnOpt.bg
    self.color = rgba(btnOpt.color or "#fff")
    self.border = btnOpt.border
    self.borderColor = rgba(btnOpt.borderColor or "#fff")
    self.hitTest = true
    self.content = btnOpt.content
    for i, v in ipairs({ ... }) do
        self:addChild(v)
    end
    self.state = { }
    if btnOpt.states then
        for i, v in pairs(btnOpt.states) do
            self.state[i] = {
                bg = v.bg or btnOpt.bg,
                color = v.color and rgba(v.color) or self.color,
                borderColor = v.borderColor and rgba(v.borderColor) or btnOpt.borderColor,
                border = v.border
            }
        end
    end
end

function Button:onDraw(dt, x, y, z)
    if self.alpha <= 0 then
        return
    end
    local bg, color = self.bg, self.color
    local border, borderColor = self.border, self.borderColor
    if self.mouseOver and self.state.mouseOver then
        bg, color = self.state.mouseOver.bg, self.state.mouseOver.color
        border, borderColor = self.state.mouseOver.border, self.state.mouseOver.borderColor
    end
    local g = love.graphics
    g.push(StackType.all)
    if bg then
        if type(bg) == 'string' then
            g.setColor(rgba(bg))
            g.rectangle(DrawMode.fill, self.pos.x + x, self.pos.y + y, self.size.w, self.size.h, self.radius, self.radius)
        elseif type(bg) == 'table' and (#bg == 3 or #bg == 4) then
            g.setColor(bg)
            g.rectangle(DrawMode.fill, self.pos.x + x, self.pos.y + y, self.size.w, self.size.h, self.radius, self.radius)
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
    if border then
        g.setColor(borderColor)
        g.rectangle(DrawMode.line, self.pos.x + x, self.pos.y + y, self.size.w - border, self.size.h - border, self.radius, self.radius, border)
    end
    if self.content then
        local content = self.content
        g.setColor(color)
        if type(content) == 'string' then
            --print(self.content)
            local t = g.newText(g.getFont(), content)
            t:setf(content, self.size.w - self.padding.left - self.padding.right, AlignMode.center)
            g.draw(t, self.pos.x + x + self.padding.left, self.pos.y + y + self.padding.top + (self.size.h - t:getHeight()) / 2)
        elseif content.is and content:is(UIComponent) then
            content:draw(dt, self.pos.x + x + self.padding.left, self.pos.y + y + self.padding.top + (self.size.h - content.size.h) / 2, z)
        elseif content.typeOf and content:typeOf("Drawable") then
            g.draw(content, self.pos.x + x + self.padding.left, self.pos.y + y + self.padding.top + (self.size.h - (content.getHeight and content.getHeight() or 0)) / 2)
        end
    end
    g.pop()
end

function Button:__tostring()
    return fmt("Panel(_id: %s, x: %s, y: %s, z: %z, w: %s, h:%s)", self._id, self.pos.x, self.pos.y, self.zIndex, self.size.w, self.size.h)
end

return Button