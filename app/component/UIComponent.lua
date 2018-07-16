local BASE = 'app.component.'
---@type Component
local Component = require(BASE .. 'base')

---@class UIComponent : Component
local UIComponent = Component:extend()

function UIComponent:new(opt)
    Component.new(self)
    self.parent = nil;
    if opt then
        self.x = opt.x or 0;
        self.y = opt.y or 0;
        self.zIndex = opt.zIndex or 0;
        self.alpha = opt.alpha or 1
    else
        self.x = 0;
        self.y = 0;
        self.zIndex = 0;
        self.alpha = 1
    end
end

function UIComponent:onDraw(x, y, zIndex)

end

function UIComponent:draw(x, y, zIndex)
    if self.alpha <= 0 then
        return
    end
    local z = self.layer * 100 + self.zIndex + zIndex
    if self.onDraw then
        self:onDraw(x, y, zIndex);
    end
    for i = 1, #self.children do
        local child = self.children[i];
        local _x, _y = self.x + x, self.y + y
        child:draw(_x, _y, self.zIndex + zIndex)
    end
end

function UIComponent:attach(parent)
    self.parent = parent;
    self.layer = parent.layer
end

function UIComponent:detach(parent)
    self.parent = nil
end

return UIComponent