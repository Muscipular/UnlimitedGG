---@class Component
Component = class("Component")

function Component:init()
    self.children = {}
    return self
end

function Component:attach(parent)

end

function Component:detach(parent)

end

function Component:addChild(comp)
    table.insert(self.children, comp)
    comp:attach(self)
end

---
-- @param comp Component a
--
function Component:removeChild(comp)
    for i, v in ipairs(self.children) do
        if v == comp then
            table.remove(self.children, i)
            if not class.isInstance(comp, Component) then
                gooi.removeComponent(comp)
            else
                comp:detach(self)
            end
            return true
        end
    end
    return false
end

function Component:draw()
    for i, v in ipairs(self.children) do
        if not class.isInstance(comp, Component) then
            v.draw()
        end
    end
end

---@return boolean
function Component:update(dt)
for i, v in ipairs(self.children) do
v.update(dt)
end
return true
end

