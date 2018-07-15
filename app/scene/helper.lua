local nk = require('nuklear')

return {
    registerNKCallback = function(scene)
        local fs = { keypressed = 3, keyreleased = 2, mousepressed = 4, mousereleased = 4, mousemoved = 5, textinput = 1, wheelmoved = 2 }
        for v, i in pairs(fs) do
            local f = scene[v]
            scene[v] = function(s, ...)
                --printAsJson({ s, v, ... })
                local b = take({ ... }, i)
                --printAsJson(b)
                if nk[v](unpack(b)) then
                    return
                end
                if f then
                    f(s, ...)
                end
            end
        end
    end
}