--require('lib.mobdebug').start()
local Application = require("app")

---@type Application
application = nil

function love.load()
    application = Application()
    application:start()
end
