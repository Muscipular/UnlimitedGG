---@class Deep
Deep = Base:extend('deep')

function Deep:new()
    self.deepQueue = {};
end

function Deep:queue(i, fn, ...)
    table.insert(self.deepQueue, { i, fn, ... });
end

function Deep:execute()
    local queue = self.deepQueue;
    self.deepQueue = {}
    table.sort(queue, function(a, b) return a[1] < b[1] end)
    for _, v in pairs(queue) do
        v[2](unpack(v, 3, #v));
    end
end

deep = Deep()