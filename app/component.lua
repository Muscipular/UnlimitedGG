---@class Component : Base
---@protected children Component[]
---@protected super Component
Component = Base:extend()

function Component:new()
    ---@type Component[]
    self.children = {}
    return self
end

---@param parent Component
function Component:attach(parent)

end

---@param parent Component
function Component:detach(parent)

end

---@param parent Component
function Component:addChild(comp)
    table.insert(self.children, comp)
    comp:attach(self)
end

---@param parent Component
function Component:removeChild(comp)
    for i, v in ipairs(self.children) do
        if v == comp then
            table.remove(self.children, i)
            comp:detach(self)
            return true
        end
    end
    return false
end

function Component:draw()
    for i, v in ipairs(self.children) do
        v:draw()
    end
end

function Component:update(dt)
    for i, v in ipairs(self.children) do
        v:update(dt)
    end
end

---@return Component[]
function Component:getChildren()
    return self.children;
end