local tiny = require('lib.tiny')

local ChildrenSystem = tiny.system(Base:extend())
ChildrenSystem.filter = tiny.requireAll("children")

function ChildrenSystem:onAdd(e)
    for i, v in ipairs(e.children) do
        v.isChild = true
        self.world.add(v)
    end
end

return ChildrenSystem
