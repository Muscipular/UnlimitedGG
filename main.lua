local Application = require("app")

application = nil

function love.load()
    application = Application()
end

function love.mousepressed(x, y, button)
    application:mousePressed(x, y, button)
end

function love.mousereleased(x, y, button)
    application:mouseReleased(x, y, button)
end

function love.textinput(text)
    application:textInput(text)
end

function love.keypressed(k, code, isrepeat)
    application:keyPressed(k, code, isrepeat)
end

function love.keyreleased(k, code, isrepeat)
    application:keyReleased(k, code, isrepeat)
end

function love.update(dt)
    application:update(dt)
end

function love.draw()
    application:draw()
end