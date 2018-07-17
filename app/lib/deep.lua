---@class Deep
Deep = Base:extend('deep')

function Deep:new()
    self.deepQueue = {};
    self.n = 0;
end

function Deep:queue(i, fn, ...)
    self.n = self.n + 1;
    table.insert(self.deepQueue, { i, self.n, fn, ... });
end

function Deep:execute()
    local queue = self.deepQueue;
    self.deepQueue = {}
    self.n = 0;
    table.sort(queue, function(a, b) return a[1] == b[1] and a[2] < b[2] or a[1] < b[1] end)
    for _, v in pairs(queue) do
        v[3](unpack(v, 4, #v));
    end
end

deep = Deep()