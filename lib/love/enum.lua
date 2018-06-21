---The different distance models.
--- 
--- Extended information can be found in the chapter "3.4. Attenuation By Distance" of the OpenAL 1.1 specification.
---@class DistanceModel
---@type DistanceModel
DistanceModel={}
---@field none @Sources do not get attenuated.
DistanceModel['none'] = 'none'
---@field inverse @Inverse distance attenuation.
DistanceModel['inverse'] = 'inverse'
---@field inverseclamped @Inverse distance attenuation. Gain is clamped. In version 0.9.2 and older this is named inverse clamped.
DistanceModel['inverseclamped'] = 'inverseclamped'
---@field linear @Linear attenuation.
DistanceModel['linear'] = 'linear'
---@field linearclamped @Linear attenuation. Gain is clamped. In version 0.9.2 and older this is named linear clamped.
DistanceModel['linearclamped'] = 'linearclamped'
---@field exponent @Exponential attenuation.
DistanceModel['exponent'] = 'exponent'
---@field exponentclamped @Exponential attenuation. Gain is clamped. In version 0.9.2 and older this is named exponent clamped.
DistanceModel['exponentclamped'] = 'exponentclamped'
---Types of audio sources.
--- 
--- A good rule of thumb is to use stream for music files and static for all short sound effects. Basically, you want to avoid loading large files into memory at once.
---@class SourceType
---@type SourceType
SourceType={}
---@field static @Decode the entire sound at once.
SourceType['static'] = 'static'
---@field stream @Stream the sound; decode it gradually.
SourceType['stream'] = 'stream'
---Units that represent time.
---@class TimeUnit
---@type TimeUnit
TimeUnit={}
---@field seconds @Regular seconds.
TimeUnit['seconds'] = 'seconds'
---@field samples @Audio samples.
TimeUnit['samples'] = 'samples'
---Arguments to love.event.push() and the like.
---@class Event
---@type Event
Event={}
---@field focus @Window focus gained or lost
Event['focus'] = 'focus'
---@field joystickaxis @Joystick axis motion
Event['joystickaxis'] = 'joystickaxis'
---@field joystickhat @Joystick hat pressed
Event['joystickhat'] = 'joystickhat'
---@field joystickpressed @Joystick pressed
Event['joystickpressed'] = 'joystickpressed'
---@field joystickreleased @Joystick released
Event['joystickreleased'] = 'joystickreleased'
---@field keypressed @Key pressed
Event['keypressed'] = 'keypressed'
---@field keyreleased @Key released
Event['keyreleased'] = 'keyreleased'
---@field mousefocus @Window mouse focus gained or lost
Event['mousefocus'] = 'mousefocus'
---@field mousepressed @Mouse pressed
Event['mousepressed'] = 'mousepressed'
---@field mousereleased @Mouse released
Event['mousereleased'] = 'mousereleased'
---@field resize @Window size changed by the user
Event['resize'] = 'resize'
---@field threaderror @A Lua error has occurred in a thread.
Event['threaderror'] = 'threaderror'
---@field quit @Quit
Event['quit'] = 'quit'
---@field visible @Window is minimized or un-minimized by the user
Event['visible'] = 'visible'
---Buffer modes for File objects.
---@class BufferMode
---@type BufferMode
BufferMode={}
---@field none @No buffering. The result of write and append operations appears immediately.
BufferMode['none'] = 'none'
---@field line @Line buffering. Write and append operations are buffered until a newline is output or the buffer size limit is reached.
BufferMode['line'] = 'line'
---@field full @Full buffering. Write and append operations are always buffered until the buffer size limit is reached.
BufferMode['full'] = 'full'
---How to decode a given FileData.
---@class FileDecoder
---@type FileDecoder
FileDecoder={}
---@field file @The data is unencoded.
FileDecoder['file'] = 'file'
---@field base64 @The data is base64-encoded.
FileDecoder['base64'] = 'base64'
---The different modes you can open a file in.
---@class FileMode
---@type FileMode
FileMode={}
---@field r @Open a file for read.
FileMode['r'] = 'r'
---@field w @Open a file for write.
FileMode['w'] = 'w'
---@field a @Open a file for append.
FileMode['a'] = 'a'
---@field c @Do not open a file (represents a closed file.)
FileMode['c'] = 'c'
---The type of a file.
---@class FileType
---@type FileType
FileType={}
---@field file @Regular file.
FileType['file'] = 'file'
---@field directory @Directory
FileType['directory'] = 'directory'
---@field symlink @Symbolic link.
FileType['symlink'] = 'symlink'
---@field other @Something completely different like a device.
FileType['other'] = 'other'
---Text alignment.
---@class AlignMode
---@type AlignMode
AlignMode={}
---@field center @Align text center.
AlignMode['center'] = 'center'
---@field left @Align text left.
AlignMode['left'] = 'left'
---@field right @Align text right.
AlignMode['right'] = 'right'
---@field justify @Align text both left and right.
AlignMode['justify'] = 'justify'
---Different types of arcs that can be drawn.
---@class ArcType
---@type ArcType
ArcType={}
---@field pie @The arc is drawn like a slice of pie, with the arc circle connected to the center at its end-points.
ArcType['pie'] = 'pie'
---@field open @The arc circle's two end-points are unconnected when the arc is drawn as a line. Behaves like the "closed" arc type when the arc is drawn in filled mode.
ArcType['open'] = 'open'
---@field closed @The arc circle's two end-points are connected to each other.
ArcType['closed'] = 'closed'
---Types of particle area spread distribution.
---@class AreaSpreadDistribution
---@type AreaSpreadDistribution
AreaSpreadDistribution={}
---@field uniform @Uniform distribution.
AreaSpreadDistribution['uniform'] = 'uniform'
---@field normal @Normal (gaussian) distribution.
AreaSpreadDistribution['normal'] = 'normal'
---@field ellipse @Uniform distribution in an ellipse.
AreaSpreadDistribution['ellipse'] = 'ellipse'
---@field none @No distribution - area spread is disabled.
AreaSpreadDistribution['none'] = 'none'
---Different ways alpha affects color blending. See BlendMode and the BlendMode Formulas for additional notes.
---@class BlendAlphaMode
---@type BlendAlphaMode
BlendAlphaMode={}
---@field alphamultiply @The RGB values of what's drawn are multiplied by the alpha values of those colors during blending. This is the default alpha mode.
BlendAlphaMode['alphamultiply'] = 'alphamultiply'
---@field premultiplied @The RGB values of what's drawn are not multiplied by the alpha values of those colors during blending. For most blend modes to work correctly with this alpha mode, the colors of a drawn object need to have had their RGB values multiplied by their alpha values at some point previously ("premultiplied alpha").
BlendAlphaMode['premultiplied'] = 'premultiplied'
---Different ways to do color blending. See BlendAlphaMode and the BlendMode Formulas for additional notes.
---@class BlendMode
---@type BlendMode
BlendMode={}
---@field alpha @Alpha blending (normal). The alpha of what's drawn determines its opacity.
BlendMode['alpha'] = 'alpha'
---@field replace @The colors of what's drawn completely replace what was on the screen, with no additional blending. The BlendAlphaMode specified in love.graphics.setBlendMode still affects what happens.
BlendMode['replace'] = 'replace'
---@field screen @"Screen" blending.
BlendMode['screen'] = 'screen'
---@field add @The pixel colors of what's drawn are added to the pixel colors already on the screen. The alpha of the screen is not modified.
BlendMode['add'] = 'add'
---@field subtract @The pixel colors of what's drawn are subtracted from the pixel colors already on the screen. The alpha of the screen is not modified.
BlendMode['subtract'] = 'subtract'
---@field multiply @The pixel colors of what's drawn are multiplied with the pixel colors already on the screen (darkening them). The alpha of drawn objects is multiplied with the alpha of the screen rather than determining how much the colors on the screen are affected, even when the "alphamultiply" BlendAlphaMode is used.
BlendMode['multiply'] = 'multiply'
---@field lighten @The pixel colors of what's drawn are compared to the existing pixel colors, and the larger of the two values for each color component is used. Only works when the "premultiplied" BlendAlphaMode is used in love.graphics.setBlendMode.
BlendMode['lighten'] = 'lighten'
---@field darken @The pixel colors of what's drawn are compared to the existing pixel colors, and the smaller of the two values for each color component is used. Only works when the "premultiplied" BlendAlphaMode is used in love.graphics.setBlendMode.
BlendMode['darken'] = 'darken'
---Canvas formats.
---@class CanvasFormat
---@type CanvasFormat
CanvasFormat={}
---@field normal @The default Canvas format - usually an alias for the rgba8 format, or the srgb format if gamma-correct rendering is enabled in LÖVE 0.10.0 and newer.
CanvasFormat['normal'] = 'normal'
---@field hdr @A format suitable for high dynamic range content - an alias for the rgba16f format, normally.
CanvasFormat['hdr'] = 'hdr'
---@field rgba8 @8 bits per channel (32 bpp) RGBA. Color channel values range from 0-255 (0-1 in shaders).
CanvasFormat['rgba8'] = 'rgba8'
---@field rgba4 @4 bits per channel (16 bpp) RGBA.
CanvasFormat['rgba4'] = 'rgba4'
---@field rgb5a1 @RGB with 5 bits each, and a 1-bit alpha channel (16 bpp).
CanvasFormat['rgb5a1'] = 'rgb5a1'
---@field rgb565 @RGB with 5, 6, and 5 bits each, respectively (16 bpp). There is no alpha channel in this format.
CanvasFormat['rgb565'] = 'rgb565'
---@field rgb10a2 @RGB with 10 bits per channel, and a 2-bit alpha channel (32 bpp).
CanvasFormat['rgb10a2'] = 'rgb10a2'
---@field rgba16f @Floating point RGBA with 16 bits per channel (64 bpp). Color values can range from [-65504, +65504].
CanvasFormat['rgba16f'] = 'rgba16f'
---@field rgba32f @Floating point RGBA with 32 bits per channel (128 bpp).
CanvasFormat['rgba32f'] = 'rgba32f'
---@field rg11b10f @Floating point RGB with 11 bits in the red and green channels, and 10 bits in the blue channel (32 bpp). There is no alpha channel. Color values can range from [0, +65024].
CanvasFormat['rg11b10f'] = 'rg11b10f'
---@field srgb @The same as rgba8, but the Canvas is interpreted as being in the sRGB color space. Everything drawn to the Canvas will be converted from linear RGB to sRGB. When the Canvas is drawn (or used in a shader), it will be decoded from sRGB to linear RGB. This reduces color banding when doing gamma-correct rendering, since sRGB encoding has more precision than linear RGB for darker colors.
CanvasFormat['srgb'] = 'srgb'
---@field r8 @Single-channel (red component) format (8 bpp).
CanvasFormat['r8'] = 'r8'
---@field rg8 @Two channels (red and green components) with 8 bits per channel (16 bpp).
CanvasFormat['rg8'] = 'rg8'
---@field r16f @Floating point single-channel format (16 bpp). Color values can range from [-65504, +65504].
CanvasFormat['r16f'] = 'r16f'
---@field rg16f @Floating point two-channel format with 16 bits per channel (32 bpp). Color values can range from [-65504, +65504].
CanvasFormat['rg16f'] = 'rg16f'
---@field r32f @Floating point single-channel format (32 bpp).
CanvasFormat['r32f'] = 'r32f'
---@field rg32f @Floating point two-channel format with 32 bits per channel (64 bpp).
CanvasFormat['rg32f'] = 'rg32f'
---Different types of per-pixel stencil test comparisons. The pixels of an object will be drawn if the comparison succeeds, for each pixel that the object touches.
---@class CompareMode
---@type CompareMode
CompareMode={}
---@field equal @The stencil value of the pixel must be equal to the supplied value.
CompareMode['equal'] = 'equal'
---@field notequal @The stencil value of the pixel must not be equal to the supplied value.
CompareMode['notequal'] = 'notequal'
---@field less @The stencil value of the pixel must be less than the supplied value.
CompareMode['less'] = 'less'
---@field lequal @The stencil value of the pixel must be less than or equal to the supplied value.
CompareMode['lequal'] = 'lequal'
---@field gequal @The stencil value of the pixel must be greater than or equal to the supplied value.
CompareMode['gequal'] = 'gequal'
---@field greater @The stencil value of the pixel must be greater than the supplied value.
CompareMode['greater'] = 'greater'
---Controls whether shapes are drawn as an outline, or filled.
---@class DrawMode
---@type DrawMode
DrawMode={}
---@field fill @Draw filled shape.
DrawMode['fill'] = 'fill'
---@field line @Draw outlined shape.
DrawMode['line'] = 'line'
---How the image is filtered when scaling.
---@class FilterMode
---@type FilterMode
FilterMode={}
---@field linear @Scale image with linear interpolation.
FilterMode['linear'] = 'linear'
---@field nearest @Scale image with nearest neighbor interpolation.
FilterMode['nearest'] = 'nearest'
---Graphics features that can be checked for with love.graphics.getSupported.
---@class GraphicsFeature
---@type GraphicsFeature
GraphicsFeature={}
---@field clampzero @Whether the "clampzero" WrapMode is supported.
GraphicsFeature['clampzero'] = 'clampzero'
---@field lighten @Whether the "lighten" and "darken" BlendModes are supported.
GraphicsFeature['lighten'] = 'lighten'
---@field multicanvasformats @Whether multiple Canvases with different formats can be used in the same love.graphics.setCanvas call.
GraphicsFeature['multicanvasformats'] = 'multicanvasformats'
---Types of system-dependent graphics limits checked for using love.graphics.getSystemLimits.
---@class GraphicsLimit
---@type GraphicsLimit
GraphicsLimit={}
---@field pointsize @The maximum size of points.
GraphicsLimit['pointsize'] = 'pointsize'
---@field texturesize @The maximum width or height of Images and Canvases.
GraphicsLimit['texturesize'] = 'texturesize'
---@field multicanvas @The maximum number of simultaneously active canvases (via love.graphics.setCanvas).
GraphicsLimit['multicanvas'] = 'multicanvas'
---@field canvasmsaa @The maximum number of antialiasing samples for a Canvas.
GraphicsLimit['canvasmsaa'] = 'canvasmsaa'
---Line join style.
---@class LineJoin
---@type LineJoin
LineJoin={}
---@field miter @The ends of the line segments beveled in an angle so that they join seamlessly.
LineJoin['miter'] = 'miter'
---@field bevel @No cap applied to the ends of the line segments.
LineJoin['bevel'] = 'bevel'
---@field none @Flattens the point where line segments join together.
LineJoin['none'] = 'none'
---The styles in which lines are drawn.
---@class LineStyle
---@type LineStyle
LineStyle={}
---@field rough @Draw rough lines.
LineStyle['rough'] = 'rough'
---@field smooth @Draw smooth lines.
LineStyle['smooth'] = 'smooth'
---How a Mesh's vertices are used when drawing.
---@class MeshDrawMode
---@type MeshDrawMode
MeshDrawMode={}
---@field fan @The vertices create a "fan" shape with the first vertex acting as the hub point. Can be easily used to draw simple convex polygons.
MeshDrawMode['fan'] = 'fan'
---@field strip @The vertices create a series of connected triangles using vertices 1, 2, 3, then 3, 2, 4 (note the order), then 3, 4, 5 and so on.
MeshDrawMode['strip'] = 'strip'
---@field triangles @The vertices create unconnected triangles.
MeshDrawMode['triangles'] = 'triangles'
---@field points @The vertices are drawn as unconnected points (see love.graphics.setPointSize.)
MeshDrawMode['points'] = 'points'
---How newly created particles are added to the ParticleSystem.
---@class ParticleInsertMode
---@type ParticleInsertMode
ParticleInsertMode={}
---@field top @Particles are inserted at the top of the ParticleSystem's list of particles.
ParticleInsertMode['top'] = 'top'
---@field bottom @Particles are inserted at the bottom of the ParticleSystem's list of particles.
ParticleInsertMode['bottom'] = 'bottom'
---@field random @Particles are inserted at random positions in the ParticleSystem's list of particles.
ParticleInsertMode['random'] = 'random'
---Usage hints for SpriteBatches and Meshes to optimize data storage and access.
---@class SpriteBatchUsage
---@type SpriteBatchUsage
SpriteBatchUsage={}
---@field dynamic @The object's data will change occasionally during its lifetime.
SpriteBatchUsage['dynamic'] = 'dynamic'
---@field static @The object will not be modified after initial sprites or vertices are added.
SpriteBatchUsage['static'] = 'static'
---@field stream @The object data will always change between draws.
SpriteBatchUsage['stream'] = 'stream'
---Graphics state stack types used with love.graphics.push.
---@class StackType
---@type StackType
StackType={}
---@field transform @The transformation stack (love.graphics.translate, love.graphics.rotate, etc.)
StackType['transform'] = 'transform'
---@field all @All love.graphics state, including transform state.
StackType['all'] = 'all'
---How a stencil function modifies the stencil values of pixels it touches.
---@class StencilAction
---@type StencilAction
StencilAction={}
---@field replace @The stencil value of a pixel will be replaced by the value specified in love.graphics.stencil, if any object touches the pixel.
StencilAction['replace'] = 'replace'
---@field increment @The stencil value of a pixel will be incremented by 1 for each object that touches the pixel. If the stencil value reaches 255 it will stay at 255.
StencilAction['increment'] = 'increment'
---@field decrement @The stencil value of a pixel will be decremented by 1 for each object that touches the pixel. If the stencil value reaches 0 it will stay at 0.
StencilAction['decrement'] = 'decrement'
---@field incrementwrap @The stencil value of a pixel will be incremented by 1 for each object that touches the pixel. If a stencil value of 255 is incremented it will be set to 0.
StencilAction['incrementwrap'] = 'incrementwrap'
---@field decrementwrap @The stencil value of a pixel will be decremented by 1 for each object that touches the pixel. If the stencil value of 0 is decremented it will be set to 255.
StencilAction['decrementwrap'] = 'decrementwrap'
---@field invert @The stencil value of a pixel will be bitwise-inverted for each object that touches the pixel. If a stencil value of 0 is inverted it will become 255.
StencilAction['invert'] = 'invert'
---How the image wraps inside a Quad with a larger quad size than image size. This also affects how Meshes with texture coordinates which are outside the range of [0, 1] are drawn, and the color returned by the Texel Shader function when using it to sample from texture coordinates outside of the range of [0, 1].
---@class WrapMode
---@type WrapMode
WrapMode={}
---@field clamp @How the image wraps inside a Quad with a larger quad size than image size. This also affects how Meshes with texture coordinates which are outside the range of [0, 1] are drawn, and the color returned by the Texel Shader function when using it to sample from texture coordinates outside of the range of [0, 1].
WrapMode['clamp'] = 'clamp'
---@field repeat @Repeat the image. Fills the whole available extent.
WrapMode['repeat'] = 'repeat'
---@field mirroredrepeat @Repeat the texture, flipping it each time it repeats. May produce better visual results than the repeat mode when the texture doesn't seamlessly tile.
WrapMode['mirroredrepeat'] = 'mirroredrepeat'
---@field clampzero @Clamp the texture. Fills the area outside the texture's normal range with transparent black (or opaque black for textures with no alpha channel.)
WrapMode['clampzero'] = 'clampzero'
---Compressed image data formats. Here and here are a couple overviews of many of the formats.
--- 
--- Unlike traditional PNG or jpeg, these formats stay compressed in RAM and in the graphics card's VRAM. This is good for saving memory space as well as improving performance, since the graphics card will be able to keep more of the image's pixels in its fast-access cache when drawing it.
---@class CompressedImageFormat
---@type CompressedImageFormat
CompressedImageFormat={}
---@field DXT1 @The DXT1 format. RGB data at 4 bits per pixel (compared to 32 bits for ImageData and regular Images.) Suitable for fully opaque images. Suitable for fully opaque images on desktop systems.
CompressedImageFormat['DXT1'] = 'DXT1'
---@field DXT3 @The DXT3 format. RGBA data at 8 bits per pixel. Smooth variations in opacity do not mix well with this format.
CompressedImageFormat['DXT3'] = 'DXT3'
---@field DXT5 @The DXT5 format. RGBA data at 8 bits per pixel. Recommended for images with varying opacity on desktop systems.
CompressedImageFormat['DXT5'] = 'DXT5'
---@field BC4 @The BC4 format (also known as 3Dc+ or ATI1.) Stores just the red channel, at 4 bits per pixel.
CompressedImageFormat['BC4'] = 'BC4'
---@field BC4s @The signed variant of the BC4 format. Same as above but the pixel values in the texture are in the range of [-1, 1] instead of [0, 1] in shaders.
CompressedImageFormat['BC4s'] = 'BC4s'
---@field BC5 @The BC5 format (also known as 3Dc or ATI2.) Stores red and green channels at 8 bits per pixel.
CompressedImageFormat['BC5'] = 'BC5'
---@field BC5s @The signed variant of the BC5 format.
CompressedImageFormat['BC5s'] = 'BC5s'
---@field BC6h @The BC6H format. Stores half-precision floating-point RGB data in the range of [0, 65504] at 8 bits per pixel. Suitable for HDR images on desktop systems.
CompressedImageFormat['BC6h'] = 'BC6h'
---@field BC6hs @The signed variant of the BC6H format. Stores RGB data in the range of [-65504, +65504].
CompressedImageFormat['BC6hs'] = 'BC6hs'
---@field BC7 @The BC7 format (also known as BPTC.) Stores RGB or RGBA data at 8 bits per pixel.
CompressedImageFormat['BC7'] = 'BC7'
---@field ETC1 @The ETC1 format. RGB data at 4 bits per pixel. Suitable for fully opaque images on older Android devices.
CompressedImageFormat['ETC1'] = 'ETC1'
---@field ETC2rgb @The RGB variant of the ETC2 format. RGB data at 4 bits per pixel. Suitable for fully opaque images on newer mobile devices.
CompressedImageFormat['ETC2rgb'] = 'ETC2rgb'
---@field ETC2rgba @The RGBA variant of the ETC2 format. RGBA data at 8 bits per pixel. Recommended for images with varying opacity on newer mobile devices.
CompressedImageFormat['ETC2rgba'] = 'ETC2rgba'
---@field ETC2rgba1 @The RGBA variant of the ETC2 format where pixels are either fully transparent or fully opaque. RGBA data at 4 bits per pixel.
CompressedImageFormat['ETC2rgba1'] = 'ETC2rgba1'
---@field EACr @The single-channel variant of the EAC format. Stores just the red channel, at 4 bits per pixel.
CompressedImageFormat['EACr'] = 'EACr'
---@field EACrs @The signed single-channel variant of the EAC format. Same as above but pixel values in the texture are in the range of [-1, 1] instead of [0, 1] in shaders.
CompressedImageFormat['EACrs'] = 'EACrs'
---@field EACrg @The two-channel variant of the EAC format. Stores red and green channels at 8 bits per pixel.
CompressedImageFormat['EACrg'] = 'EACrg'
---@field EACrgs @The signed two-channel variant of the EAC format.
CompressedImageFormat['EACrgs'] = 'EACrgs'
---@field PVR1rgb2 @The 2 bit per pixel RGB variant of the PVRTC1 format. Stores RGB data at 2 bits per pixel. Textures compressed with PVRTC1 formats must be square and power-of-two sized.
CompressedImageFormat['PVR1rgb2'] = 'PVR1rgb2'
---@field PVR1rgb4 @The 4 bit per pixel RGB variant of the PVRTC1 format. Stores RGB data at 4 bits per pixel.
CompressedImageFormat['PVR1rgb4'] = 'PVR1rgb4'
---@field PVR1rgba2 @The 2 bit per pixel RGBA variant of the PVRTC1 format.
CompressedImageFormat['PVR1rgba2'] = 'PVR1rgba2'
---@field PVR1rgba4 @The 4 bit per pixel RGBA variant of the PVRTC1 format.
CompressedImageFormat['PVR1rgba4'] = 'PVR1rgba4'
---@field ASTC4x4 @The 4x4 pixels per block variant of the ASTC format. RGBA data at 8 bits per pixel.
CompressedImageFormat['ASTC4x4'] = 'ASTC4x4'
---@field ASTC5x4 @The 5x4 pixels per block variant of the ASTC format. RGBA data at 6.4 bits per pixel.
CompressedImageFormat['ASTC5x4'] = 'ASTC5x4'
---@field ASTC5x5 @The 5x5 pixels per block variant of the ASTC format. RGBA data at 5.12 bits per pixel.
CompressedImageFormat['ASTC5x5'] = 'ASTC5x5'
---@field ASTC6x5 @The 6x5 pixels per block variant of the ASTC format. RGBA data at 4.27 bits per pixel.
CompressedImageFormat['ASTC6x5'] = 'ASTC6x5'
---@field ASTC6x6 @The 6x6 pixels per block variant of the ASTC format. RGBA data at 3.56 bits per pixel.
CompressedImageFormat['ASTC6x6'] = 'ASTC6x6'
---@field ASTC8x5 @The 8x5 pixels per block variant of the ASTC format. RGBA data at 3.2 bits per pixel.
CompressedImageFormat['ASTC8x5'] = 'ASTC8x5'
---@field ASTC8x6 @The 8x6 pixels per block variant of the ASTC format. RGBA data at 2.67 bits per pixel.
CompressedImageFormat['ASTC8x6'] = 'ASTC8x6'
---@field ASTC8x8 @The 8x8 pixels per block variant of the ASTC format. RGBA data at 2 bits per pixel.
CompressedImageFormat['ASTC8x8'] = 'ASTC8x8'
---@field ASTC10x5 @The 10x5 pixels per block variant of the ASTC format. RGBA data at 2.56 bits per pixel.
CompressedImageFormat['ASTC10x5'] = 'ASTC10x5'
---@field ASTC10x6 @The 10x6 pixels per block variant of the ASTC format. RGBA data at 2.13 bits per pixel.
CompressedImageFormat['ASTC10x6'] = 'ASTC10x6'
---@field ASTC10x8 @The 10x8 pixels per block variant of the ASTC format. RGBA data at 1.6 bits per pixel.
CompressedImageFormat['ASTC10x8'] = 'ASTC10x8'
---@field ASTC10x10 @The 10x10 pixels per block variant of the ASTC format. RGBA data at 1.28 bits per pixel.
CompressedImageFormat['ASTC10x10'] = 'ASTC10x10'
---@field ASTC12x10 @The 12x10 pixels per block variant of the ASTC format. RGBA data at 1.07 bits per pixel.
CompressedImageFormat['ASTC12x10'] = 'ASTC12x10'
---@field ASTC12x12 @The 12x12 pixels per block variant of the ASTC format. RGBA data at 0.89 bits per pixel.
CompressedImageFormat['ASTC12x12'] = 'ASTC12x12'
---Encoded image formats.
---@class ImageFormat
---@type ImageFormat
ImageFormat={}
---@field tga @Targa image format.
ImageFormat['tga'] = 'tga'
---@field png @PNG image format.
ImageFormat['png'] = 'png'
---Virtual gamepad axes.
---@class GamepadAxis
---@type GamepadAxis
GamepadAxis={}
---@field leftx @The x-axis of the left thumbstick.
GamepadAxis['leftx'] = 'leftx'
---@field lefty @The y-axis of the left thumbstick.
GamepadAxis['lefty'] = 'lefty'
---@field rightx @The x-axis of the right thumbstick.
GamepadAxis['rightx'] = 'rightx'
---@field righty @The y-axis of the right thumbstick.
GamepadAxis['righty'] = 'righty'
---@field triggerleft @Left analog trigger.
GamepadAxis['triggerleft'] = 'triggerleft'
---@field triggerright @Right analog trigger.
GamepadAxis['triggerright'] = 'triggerright'
---Virtual gamepad buttons.
---@class GamepadButton
---@type GamepadButton
GamepadButton={}
---@field a @Bottom face button (A).
GamepadButton['a'] = 'a'
---@field b @Right face button (B).
GamepadButton['b'] = 'b'
---@field x @Left face button (X).
GamepadButton['x'] = 'x'
---@field y @Top face button (Y).
GamepadButton['y'] = 'y'
---@field back @Back button.
GamepadButton['back'] = 'back'
---@field guide @Guide button.
GamepadButton['guide'] = 'guide'
---@field start @Start button.
GamepadButton['start'] = 'start'
---@field leftstick @Left stick click button.
GamepadButton['leftstick'] = 'leftstick'
---@field rightstick @Right stick click button.
GamepadButton['rightstick'] = 'rightstick'
---@field leftshoulder @Left bumper.
GamepadButton['leftshoulder'] = 'leftshoulder'
---@field rightshoulder @Right bumper.
GamepadButton['rightshoulder'] = 'rightshoulder'
---@field dpup @D-pad up.
GamepadButton['dpup'] = 'dpup'
---@field dpdown @D-pad down.
GamepadButton['dpdown'] = 'dpdown'
---@field dpleft @D-pad left.
GamepadButton['dpleft'] = 'dpleft'
---@field dpright @D-pad right.
GamepadButton['dpright'] = 'dpright'
---Joystick hat positions.
---@class JoystickHat
---@type JoystickHat
JoystickHat={}
---@field c @Centered
JoystickHat['c'] = 'c'
---@field d @Down
JoystickHat['d'] = 'd'
---@field l @Left
JoystickHat['l'] = 'l'
---@field ld @Left+Down
JoystickHat['ld'] = 'ld'
---@field lu @Left+Up
JoystickHat['lu'] = 'lu'
---@field r @Right
JoystickHat['r'] = 'r'
---@field rd @Right+Down
JoystickHat['rd'] = 'rd'
---@field ru @Right+Up
JoystickHat['ru'] = 'ru'
---@field u @Up
JoystickHat['u'] = 'u'
---Types of Joystick inputs.
---@class JoystickInputType
---@type JoystickInputType
JoystickInputType={}
---@field axis @Analog axis.
JoystickInputType['axis'] = 'axis'
---@field button @Button.
JoystickInputType['button'] = 'button'
---@field hat @8-direction hat value.
JoystickInputType['hat'] = 'hat'
---All the keys you can press. Note that some keys may not be available on your keyboard or system.
---@class KeyConstant
---@type KeyConstant
KeyConstant={}
---@field a @The A key
KeyConstant['a'] = 'a'
---@field b @The B key
KeyConstant['b'] = 'b'
---@field c @The C key
KeyConstant['c'] = 'c'
---@field d @The D key
KeyConstant['d'] = 'd'
---@field e @The E key
KeyConstant['e'] = 'e'
---@field f @The F key
KeyConstant['f'] = 'f'
---@field g @The G key
KeyConstant['g'] = 'g'
---@field h @The H key
KeyConstant['h'] = 'h'
---@field i @The I key
KeyConstant['i'] = 'i'
---@field j @The J key
KeyConstant['j'] = 'j'
---@field k @The K key
KeyConstant['k'] = 'k'
---@field l @The L key
KeyConstant['l'] = 'l'
---@field m @The M key
KeyConstant['m'] = 'm'
---@field n @The N key
KeyConstant['n'] = 'n'
---@field o @The O key
KeyConstant['o'] = 'o'
---@field p @The P key
KeyConstant['p'] = 'p'
---@field q @The Q key
KeyConstant['q'] = 'q'
---@field r @The R key
KeyConstant['r'] = 'r'
---@field s @The S key
KeyConstant['s'] = 's'
---@field t @The T key
KeyConstant['t'] = 't'
---@field u @The U key
KeyConstant['u'] = 'u'
---@field v @The V key
KeyConstant['v'] = 'v'
---@field w @The W key
KeyConstant['w'] = 'w'
---@field x @The X key
KeyConstant['x'] = 'x'
---@field y @The Y key
KeyConstant['y'] = 'y'
---@field z @The Z key
KeyConstant['z'] = 'z'
---@field 0 @The zero key
KeyConstant['0'] = '0'
---@field 1 @The one key
KeyConstant['1'] = '1'
---@field 2 @The two key
KeyConstant['2'] = '2'
---@field 3 @The three key
KeyConstant['3'] = '3'
---@field 4 @The four key
KeyConstant['4'] = '4'
---@field 5 @The five key
KeyConstant['5'] = '5'
---@field 6 @The six key
KeyConstant['6'] = '6'
---@field 7 @The seven key
KeyConstant['7'] = '7'
---@field 8 @The eight key
KeyConstant['8'] = '8'
---@field 9 @The nine key
KeyConstant['9'] = '9'
---@field space @Space key
KeyConstant['space'] = 'space'
---@field ! @Exclamation mark key
KeyConstant['!'] = '!'
---@field " @Double quote key
KeyConstant['"'] = '"'
---@field # @Hash key
KeyConstant['#'] = '#'
---@field $ @Dollar key
KeyConstant['$'] = '$'
---@field & @Ampersand key
KeyConstant['&'] = '&'
---@field ' @Single quote key
KeyConstant['\''] = '\''
---@field ( @Left parenthesis key
KeyConstant['('] = '('
---@field ) @Right parenthesis key
KeyConstant[')'] = ')'
---@field * @Asterisk key
KeyConstant['*'] = '*'
---@field + @Plus key
KeyConstant['+'] = '+'
---@field , @Comma key
KeyConstant[','] = ','
---@field - @Hyphen-minus key
KeyConstant['-'] = '-'
---@field . @Full stop key
KeyConstant['.'] = '.'
---@field / @Slash key
KeyConstant['/'] = '/'
---@field : @Colon key
KeyConstant[':'] = ':'
---@field ; @Semicolon key
KeyConstant[';'] = ';'
---@field < @Less-than key
KeyConstant['<'] = '<'
---@field = @Equal key
KeyConstant['='] = '='
---@field > @Greater-than key
KeyConstant['>'] = '>'
---@field ? @Question mark key
KeyConstant['?'] = '?'
---@field @ @At sign key
KeyConstant['@'] = '@'
---@field [ @Left square bracket key
KeyConstant['['] = '['
---@field \ @Backslash key
KeyConstant['\\'] = '\\'
---@field ] @Right square bracket key
KeyConstant[']'] = ']'
---@field ^ @Caret key
KeyConstant['^'] = '^'
---@field _ @Underscore key
KeyConstant['_'] = '_'
---@field ` @Grave accent key
KeyConstant['`'] = '`'
---@field kp0 @The numpad zero key
KeyConstant['kp0'] = 'kp0'
---@field kp1 @The numpad one key
KeyConstant['kp1'] = 'kp1'
---@field kp2 @The numpad two key
KeyConstant['kp2'] = 'kp2'
---@field kp3 @The numpad three key
KeyConstant['kp3'] = 'kp3'
---@field kp4 @The numpad four key
KeyConstant['kp4'] = 'kp4'
---@field kp5 @The numpad five key
KeyConstant['kp5'] = 'kp5'
---@field kp6 @The numpad six key
KeyConstant['kp6'] = 'kp6'
---@field kp7 @The numpad seven key
KeyConstant['kp7'] = 'kp7'
---@field kp8 @The numpad eight key
KeyConstant['kp8'] = 'kp8'
---@field kp9 @The numpad nine key
KeyConstant['kp9'] = 'kp9'
---@field kp. @The numpad decimal point key
KeyConstant['kp.'] = 'kp.'
---@field kp/ @The numpad division key
KeyConstant['kp/'] = 'kp/'
---@field kp* @The numpad multiplication key
KeyConstant['kp*'] = 'kp*'
---@field kp- @The numpad substraction key
KeyConstant['kp-'] = 'kp-'
---@field kp+ @The numpad addition key
KeyConstant['kp+'] = 'kp+'
---@field kpenter @The numpad enter key
KeyConstant['kpenter'] = 'kpenter'
---@field kp= @The numpad equals key
KeyConstant['kp='] = 'kp='
---@field up @Up cursor key
KeyConstant['up'] = 'up'
---@field down @Down cursor key
KeyConstant['down'] = 'down'
---@field right @Right cursor key
KeyConstant['right'] = 'right'
---@field left @Left cursor key
KeyConstant['left'] = 'left'
---@field home @Home key
KeyConstant['home'] = 'home'
---@field end @End key
KeyConstant['end'] = 'end'
---@field pageup @Page up key
KeyConstant['pageup'] = 'pageup'
---@field pagedown @Page down key
KeyConstant['pagedown'] = 'pagedown'
---@field insert @Insert key
KeyConstant['insert'] = 'insert'
---@field backspace @Backspace key
KeyConstant['backspace'] = 'backspace'
---@field tab @Tab key
KeyConstant['tab'] = 'tab'
---@field clear @Clear key
KeyConstant['clear'] = 'clear'
---@field return @Return key
KeyConstant['return'] = 'return'
---@field delete @Delete key
KeyConstant['delete'] = 'delete'
---@field f1 @The 1st function key
KeyConstant['f1'] = 'f1'
---@field f2 @The 2nd function key
KeyConstant['f2'] = 'f2'
---@field f3 @The 3rd function key
KeyConstant['f3'] = 'f3'
---@field f4 @The 4th function key
KeyConstant['f4'] = 'f4'
---@field f5 @The 5th function key
KeyConstant['f5'] = 'f5'
---@field f6 @The 6th function key
KeyConstant['f6'] = 'f6'
---@field f7 @The 7th function key
KeyConstant['f7'] = 'f7'
---@field f8 @The 8th function key
KeyConstant['f8'] = 'f8'
---@field f9 @The 9th function key
KeyConstant['f9'] = 'f9'
---@field f10 @The 10th function key
KeyConstant['f10'] = 'f10'
---@field f11 @The 11th function key
KeyConstant['f11'] = 'f11'
---@field f12 @The 12th function key
KeyConstant['f12'] = 'f12'
---@field f13 @The 13th function key
KeyConstant['f13'] = 'f13'
---@field f14 @The 14th function key
KeyConstant['f14'] = 'f14'
---@field f15 @The 15th function key
KeyConstant['f15'] = 'f15'
---@field numlock @Num-lock key
KeyConstant['numlock'] = 'numlock'
---@field capslock @Caps-lock key
KeyConstant['capslock'] = 'capslock'
---@field scrollock @Scroll-lock key
KeyConstant['scrollock'] = 'scrollock'
---@field rshift @Right shift key
KeyConstant['rshift'] = 'rshift'
---@field lshift @Left shift key
KeyConstant['lshift'] = 'lshift'
---@field rctrl @Right control key
KeyConstant['rctrl'] = 'rctrl'
---@field lctrl @Left control key
KeyConstant['lctrl'] = 'lctrl'
---@field ralt @Right alt key
KeyConstant['ralt'] = 'ralt'
---@field lalt @Left alt key
KeyConstant['lalt'] = 'lalt'
---@field rmeta @Right meta key
KeyConstant['rmeta'] = 'rmeta'
---@field lmeta @Left meta key
KeyConstant['lmeta'] = 'lmeta'
---@field lsuper @Left super key
KeyConstant['lsuper'] = 'lsuper'
---@field rsuper @Right super key
KeyConstant['rsuper'] = 'rsuper'
---@field mode @Mode key
KeyConstant['mode'] = 'mode'
---@field compose @Compose key
KeyConstant['compose'] = 'compose'
---@field pause @Pause key
KeyConstant['pause'] = 'pause'
---@field escape @Escape key
KeyConstant['escape'] = 'escape'
---@field help @Help key
KeyConstant['help'] = 'help'
---@field print @Print key
KeyConstant['print'] = 'print'
---@field sysreq @System request key
KeyConstant['sysreq'] = 'sysreq'
---@field break @Break key
KeyConstant['break'] = 'break'
---@field menu @Menu key
KeyConstant['menu'] = 'menu'
---@field power @Power key
KeyConstant['power'] = 'power'
---@field euro @Euro (&euro;) key
KeyConstant['euro'] = 'euro'
---@field undo @Undo key
KeyConstant['undo'] = 'undo'
---@field www @WWW key
KeyConstant['www'] = 'www'
---@field mail @Mail key
KeyConstant['mail'] = 'mail'
---@field calculator @Calculator key
KeyConstant['calculator'] = 'calculator'
---@field appsearch @Application search key
KeyConstant['appsearch'] = 'appsearch'
---@field apphome @Application home key
KeyConstant['apphome'] = 'apphome'
---@field appback @Application back key
KeyConstant['appback'] = 'appback'
---@field appforward @Application forward key
KeyConstant['appforward'] = 'appforward'
---@field apprefresh @Application refresh key
KeyConstant['apprefresh'] = 'apprefresh'
---@field appbookmarks @Application bookmarks key
KeyConstant['appbookmarks'] = 'appbookmarks'
---Keyboard scancodes.
--- 
--- Scancodes are keyboard layout-independent, so the scancode "w" will be generated if the key in the same place as the "w" key on an American QWERTY keyboard is pressed, no matter what the key is labelled or what the user's operating system settings are.
--- 
--- Using scancodes, rather than keycodes, is useful because keyboards with layouts differing from the US/UK layout(s) might have keys that generate 'unknown' keycodes, but the scancodes will still be detected. This however would necessitate having a list for each keyboard layout one would choose to support.
--- 
--- One could use textinput or textedited instead, but those only give back the end result of keys used, i.e. you can't get modifiers on their own from it, only the final symbols that were generated.
---@class Scancode
---@type Scancode
Scancode={}
---@field a @The 'A' key on an American layout.
Scancode['a'] = 'a'
---@field b @The 'B' key on an American layout.
Scancode['b'] = 'b'
---@field c @The 'C' key on an American layout.
Scancode['c'] = 'c'
---@field d @The 'D' key on an American layout.
Scancode['d'] = 'd'
---@field e @The 'E' key on an American layout.
Scancode['e'] = 'e'
---@field f @The 'F' key on an American layout.
Scancode['f'] = 'f'
---@field g @The 'G' key on an American layout.
Scancode['g'] = 'g'
---@field h @The 'H' key on an American layout.
Scancode['h'] = 'h'
---@field i @The 'I' key on an American layout.
Scancode['i'] = 'i'
---@field j @The 'J' key on an American layout.
Scancode['j'] = 'j'
---@field k @The 'K' key on an American layout.
Scancode['k'] = 'k'
---@field l @The 'L' key on an American layout.
Scancode['l'] = 'l'
---@field m @The 'M' key on an American layout.
Scancode['m'] = 'm'
---@field n @The 'N' key on an American layout.
Scancode['n'] = 'n'
---@field o @The 'O' key on an American layout.
Scancode['o'] = 'o'
---@field p @The 'P' key on an American layout.
Scancode['p'] = 'p'
---@field q @The 'Q' key on an American layout.
Scancode['q'] = 'q'
---@field r @The 'R' key on an American layout.
Scancode['r'] = 'r'
---@field s @The 'S' key on an American layout.
Scancode['s'] = 's'
---@field t @The 'T' key on an American layout.
Scancode['t'] = 't'
---@field u @The 'U' key on an American layout.
Scancode['u'] = 'u'
---@field v @The 'V' key on an American layout.
Scancode['v'] = 'v'
---@field w @The 'W' key on an American layout.
Scancode['w'] = 'w'
---@field x @The 'X' key on an American layout.
Scancode['x'] = 'x'
---@field y @The 'Y' key on an American layout.
Scancode['y'] = 'y'
---@field z @The 'Z' key on an American layout.
Scancode['z'] = 'z'
---@field 1 @The '1' key on an American layout.
Scancode['1'] = '1'
---@field 2 @The '2' key on an American layout.
Scancode['2'] = '2'
---@field 3 @The '3' key on an American layout.
Scancode['3'] = '3'
---@field 4 @The '4' key on an American layout.
Scancode['4'] = '4'
---@field 5 @The '5' key on an American layout.
Scancode['5'] = '5'
---@field 6 @The '6' key on an American layout.
Scancode['6'] = '6'
---@field 7 @The '7' key on an American layout.
Scancode['7'] = '7'
---@field 8 @The '8' key on an American layout.
Scancode['8'] = '8'
---@field 9 @The '9' key on an American layout.
Scancode['9'] = '9'
---@field 0 @The '0' key on an American layout.
Scancode['0'] = '0'
---@field return @The 'return' / 'enter' key on an American layout.
Scancode['return'] = 'return'
---@field escape @The 'escape' key on an American layout.
Scancode['escape'] = 'escape'
---@field backspace @The 'backspace' key on an American layout.
Scancode['backspace'] = 'backspace'
---@field tab @The 'tab' key on an American layout.
Scancode['tab'] = 'tab'
---@field space @The spacebar on an American layout.
Scancode['space'] = 'space'
---@field - @The minus key on an American layout.
Scancode['-'] = '-'
---@field = @The equals key on an American layout.
Scancode['='] = '='
---@field [ @The left-bracket key on an American layout.
Scancode['['] = '['
---@field ] @The right-bracket key on an American layout.
Scancode[']'] = ']'
---@field \ @The backslash key on an American layout.
Scancode['\\'] = '\\'
---@field nonus# @The non-U.S. hash scancode.
Scancode['nonus#'] = 'nonus#'
---@field ; @The semicolon key on an American layout.
Scancode[';'] = ';'
---@field ' @The apostrophe key on an American layout.
Scancode['\''] = '\''
---@field ` @The back-tick / grave key on an American layout.
Scancode['`'] = '`'
---@field , @The comma key on an American layout.
Scancode[','] = ','
---@field . @The period key on an American layout.
Scancode['.'] = '.'
---@field / @The forward-slash key on an American layout.
Scancode['/'] = '/'
---@field capslock @The capslock key on an American layout.
Scancode['capslock'] = 'capslock'
---@field f1 @The F1 key on an American layout.
Scancode['f1'] = 'f1'
---@field f2 @The F2 key on an American layout.
Scancode['f2'] = 'f2'
---@field f3 @The F3 key on an American layout.
Scancode['f3'] = 'f3'
---@field f4 @The F4 key on an American layout.
Scancode['f4'] = 'f4'
---@field f5 @The F5 key on an American layout.
Scancode['f5'] = 'f5'
---@field f6 @The F6 key on an American layout.
Scancode['f6'] = 'f6'
---@field f7 @The F7 key on an American layout.
Scancode['f7'] = 'f7'
---@field f8 @The F8 key on an American layout.
Scancode['f8'] = 'f8'
---@field f9 @The F9 key on an American layout.
Scancode['f9'] = 'f9'
---@field f10 @The F10 key on an American layout.
Scancode['f10'] = 'f10'
---@field f11 @The F11 key on an American layout.
Scancode['f11'] = 'f11'
---@field f12 @The F12 key on an American layout.
Scancode['f12'] = 'f12'
---@field f13 @The F13 key on an American layout.
Scancode['f13'] = 'f13'
---@field f14 @The F14 key on an American layout.
Scancode['f14'] = 'f14'
---@field f15 @The F15 key on an American layout.
Scancode['f15'] = 'f15'
---@field f16 @The F16 key on an American layout.
Scancode['f16'] = 'f16'
---@field f17 @The F17 key on an American layout.
Scancode['f17'] = 'f17'
---@field f18 @The F18 key on an American layout.
Scancode['f18'] = 'f18'
---@field f19 @The F19 key on an American layout.
Scancode['f19'] = 'f19'
---@field f20 @The F20 key on an American layout.
Scancode['f20'] = 'f20'
---@field f21 @The F21 key on an American layout.
Scancode['f21'] = 'f21'
---@field f22 @The F22 key on an American layout.
Scancode['f22'] = 'f22'
---@field f23 @The F23 key on an American layout.
Scancode['f23'] = 'f23'
---@field f24 @The F24 key on an American layout.
Scancode['f24'] = 'f24'
---@field lctrl @The left control key on an American layout.
Scancode['lctrl'] = 'lctrl'
---@field lshift @The left shift key on an American layout.
Scancode['lshift'] = 'lshift'
---@field lalt @The left alt / option key on an American layout.
Scancode['lalt'] = 'lalt'
---@field lgui @The left GUI (command / windows / super) key on an American layout.
Scancode['lgui'] = 'lgui'
---@field rctrl @The right control key on an American layout.
Scancode['rctrl'] = 'rctrl'
---@field rshift @The right shift key on an American layout.
Scancode['rshift'] = 'rshift'
---@field ralt @The right alt / option key on an American layout.
Scancode['ralt'] = 'ralt'
---@field rgui @The right GUI (command / windows / super) key on an American layout.
Scancode['rgui'] = 'rgui'
---@field printscreen @The printscreen key on an American layout.
Scancode['printscreen'] = 'printscreen'
---@field scrolllock @The scroll-lock key on an American layout.
Scancode['scrolllock'] = 'scrolllock'
---@field pause @The pause key on an American layout.
Scancode['pause'] = 'pause'
---@field insert @The insert key on an American layout.
Scancode['insert'] = 'insert'
---@field home @The home key on an American layout.
Scancode['home'] = 'home'
---@field numlock @The numlock / clear key on an American layout.
Scancode['numlock'] = 'numlock'
---@field pageup @The page-up key on an American layout.
Scancode['pageup'] = 'pageup'
---@field delete @The forward-delete key on an American layout.
Scancode['delete'] = 'delete'
---@field end @The end key on an American layout.
Scancode['end'] = 'end'
---@field pagedown @The page-down key on an American layout.
Scancode['pagedown'] = 'pagedown'
---@field right @The right-arrow key on an American layout.
Scancode['right'] = 'right'
---@field left @The left-arrow key on an American layout.
Scancode['left'] = 'left'
---@field down @The down-arrow key on an American layout.
Scancode['down'] = 'down'
---@field up @The up-arrow key on an American layout.
Scancode['up'] = 'up'
---@field nonusbackslash @The non-U.S. backslash scancode.
Scancode['nonusbackslash'] = 'nonusbackslash'
---@field application @The application key on an American layout. Windows contextual menu, compose key.
Scancode['application'] = 'application'
---@field execute @The 'execute' key on an American layout.
Scancode['execute'] = 'execute'
---@field help @The 'help' key on an American layout.
Scancode['help'] = 'help'
---@field menu @The 'menu' key on an American layout.
Scancode['menu'] = 'menu'
---@field select @The 'select' key on an American layout.
Scancode['select'] = 'select'
---@field stop @The 'stop' key on an American layout.
Scancode['stop'] = 'stop'
---@field again @The 'again' key on an American layout.
Scancode['again'] = 'again'
---@field undo @The 'undo' key on an American layout.
Scancode['undo'] = 'undo'
---@field cut @The 'cut' key on an American layout.
Scancode['cut'] = 'cut'
---@field copy @The 'copy' key on an American layout.
Scancode['copy'] = 'copy'
---@field paste @The 'paste' key on an American layout.
Scancode['paste'] = 'paste'
---@field find @The 'find' key on an American layout.
Scancode['find'] = 'find'
---@field kp/ @The keypad forward-slash key on an American layout.
Scancode['kp/'] = 'kp/'
---@field kp* @The keypad '*' key on an American layout.
Scancode['kp*'] = 'kp*'
---@field kp- @The keypad minus key on an American layout.
Scancode['kp-'] = 'kp-'
---@field kp+ @The keypad plus key on an American layout.
Scancode['kp+'] = 'kp+'
---@field kp= @The keypad equals key on an American layout.
Scancode['kp='] = 'kp='
---@field kpenter @The keypad enter key on an American layout.
Scancode['kpenter'] = 'kpenter'
---@field kp1 @The keypad '1' key on an American layout.
Scancode['kp1'] = 'kp1'
---@field kp2 @The keypad '2' key on an American layout.
Scancode['kp2'] = 'kp2'
---@field kp3 @The keypad '3' key on an American layout.
Scancode['kp3'] = 'kp3'
---@field kp4 @The keypad '4' key on an American layout.
Scancode['kp4'] = 'kp4'
---@field kp5 @The keypad '5' key on an American layout.
Scancode['kp5'] = 'kp5'
---@field kp6 @The keypad '6' key on an American layout.
Scancode['kp6'] = 'kp6'
---@field kp7 @The keypad '7' key on an American layout.
Scancode['kp7'] = 'kp7'
---@field kp8 @The keypad '8' key on an American layout.
Scancode['kp8'] = 'kp8'
---@field kp9 @The keypad '9' key on an American layout.
Scancode['kp9'] = 'kp9'
---@field kp0 @The keypad '0' key on an American layout.
Scancode['kp0'] = 'kp0'
---@field kp. @The keypad period key on an American layout.
Scancode['kp.'] = 'kp.'
---@field international1 @The 1st international key on an American layout. Used on Asian keyboards.
Scancode['international1'] = 'international1'
---@field international2 @The 2nd international key on an American layout.
Scancode['international2'] = 'international2'
---@field international3 @The 3rd international key on an American layout. Yen.
Scancode['international3'] = 'international3'
---@field international4 @The 4th international key on an American layout.
Scancode['international4'] = 'international4'
---@field international5 @The 5th international key on an American layout.
Scancode['international5'] = 'international5'
---@field international6 @The 6th international key on an American layout.
Scancode['international6'] = 'international6'
---@field international7 @The 7th international key on an American layout.
Scancode['international7'] = 'international7'
---@field international8 @The 8th international key on an American layout.
Scancode['international8'] = 'international8'
---@field international9 @The 9th international key on an American layout.
Scancode['international9'] = 'international9'
---@field lang1 @Hangul/English toggle scancode.
Scancode['lang1'] = 'lang1'
---@field lang2 @Hanja conversion scancode.
Scancode['lang2'] = 'lang2'
---@field lang3 @Katakana scancode.
Scancode['lang3'] = 'lang3'
---@field lang4 @Hiragana scancode.
Scancode['lang4'] = 'lang4'
---@field lang5 @Zenkaku/Hankaku scancode.
Scancode['lang5'] = 'lang5'
---@field mute @The mute key on an American layout.
Scancode['mute'] = 'mute'
---@field volumeup @The volume up key on an American layout.
Scancode['volumeup'] = 'volumeup'
---@field volumedown @The volume down key on an American layout.
Scancode['volumedown'] = 'volumedown'
---@field audionext @The audio next track key on an American layout.
Scancode['audionext'] = 'audionext'
---@field audioprev @The audio previous track key on an American layout.
Scancode['audioprev'] = 'audioprev'
---@field audiostop @The audio stop key on an American layout.
Scancode['audiostop'] = 'audiostop'
---@field audioplay @The audio play key on an American layout.
Scancode['audioplay'] = 'audioplay'
---@field audiomute @The audio mute key on an American layout.
Scancode['audiomute'] = 'audiomute'
---@field mediaselect @The media select key on an American layout.
Scancode['mediaselect'] = 'mediaselect'
---@field www @The 'WWW' key on an American layout.
Scancode['www'] = 'www'
---@field mail @The Mail key on an American layout.
Scancode['mail'] = 'mail'
---@field calculator @The calculator key on an American layout.
Scancode['calculator'] = 'calculator'
---@field computer @The 'computer' key on an American layout.
Scancode['computer'] = 'computer'
---@field acsearch @The AC Search key on an American layout.
Scancode['acsearch'] = 'acsearch'
---@field achome @The AC Home key on an American layout.
Scancode['achome'] = 'achome'
---@field acback @The AC Back key on an American layout.
Scancode['acback'] = 'acback'
---@field acforward @The AC Forward key on an American layout.
Scancode['acforward'] = 'acforward'
---@field acstop @Th AC Stop key on an American layout.
Scancode['acstop'] = 'acstop'
---@field acrefresh @The AC Refresh key on an American layout.
Scancode['acrefresh'] = 'acrefresh'
---@field acbookmarks @The AC Bookmarks key on an American layout.
Scancode['acbookmarks'] = 'acbookmarks'
---@field power @The system power scancode.
Scancode['power'] = 'power'
---@field brightnessdown @The brightness-down scancode.
Scancode['brightnessdown'] = 'brightnessdown'
---@field brightnessup @The brightness-up scancode.
Scancode['brightnessup'] = 'brightnessup'
---@field displayswitch @The display switch scancode.
Scancode['displayswitch'] = 'displayswitch'
---@field kbdillumtoggle @The keyboard illumination toggle scancode.
Scancode['kbdillumtoggle'] = 'kbdillumtoggle'
---@field kbdillumdown @The keyboard illumination down scancode.
Scancode['kbdillumdown'] = 'kbdillumdown'
---@field kbdillumup @The keyboard illumination up scancode.
Scancode['kbdillumup'] = 'kbdillumup'
---@field eject @The eject scancode.
Scancode['eject'] = 'eject'
---@field sleep @The system sleep scancode.
Scancode['sleep'] = 'sleep'
---@field alterase @The alt-erase key on an American layout.
Scancode['alterase'] = 'alterase'
---@field sysreq @The sysreq key on an American layout.
Scancode['sysreq'] = 'sysreq'
---@field cancel @The 'cancel' key on an American layout.
Scancode['cancel'] = 'cancel'
---@field clear @The 'clear' key on an American layout.
Scancode['clear'] = 'clear'
---@field prior @The 'prior' key on an American layout.
Scancode['prior'] = 'prior'
---@field return2 @The 'return2' key on an American layout.
Scancode['return2'] = 'return2'
---@field separator @The 'separator' key on an American layout.
Scancode['separator'] = 'separator'
---@field out @The 'out' key on an American layout.
Scancode['out'] = 'out'
---@field oper @The 'oper' key on an American layout.
Scancode['oper'] = 'oper'
---@field clearagain @The 'clearagain' key on an American layout.
Scancode['clearagain'] = 'clearagain'
---@field crsel @The 'crsel' key on an American layout.
Scancode['crsel'] = 'crsel'
---@field exsel @The 'exsel' key on an American layout.
Scancode['exsel'] = 'exsel'
---@field kp00 @The keypad 00 key on an American layout.
Scancode['kp00'] = 'kp00'
---@field kp000 @The keypad 000 key on an American layout.
Scancode['kp000'] = 'kp000'
---@field thsousandsseparator @The thousands-separator key on an American layout.
Scancode['thsousandsseparator'] = 'thsousandsseparator'
---@field decimalseparator @The decimal separator key on an American layout.
Scancode['decimalseparator'] = 'decimalseparator'
---@field currencyunit @The currency unit key on an American layout.
Scancode['currencyunit'] = 'currencyunit'
---@field currencysubunit @The currency sub-unit key on an American layout.
Scancode['currencysubunit'] = 'currencysubunit'
---@field app1 @The 'app1' scancode.
Scancode['app1'] = 'app1'
---@field app2 @The 'app2' scancode.
Scancode['app2'] = 'app2'
---@field unknown @An unknown key.
Scancode['unknown'] = 'unknown'
---Compressed data formats.
---@class CompressedDataFormat
---@type CompressedDataFormat
CompressedDataFormat={}
---@field lz4 @The LZ4 compression format. Compresses and decompresses very quickly, but the compression ratio is not the best. LZ4-HC is used when compression level 9 is specified.
CompressedDataFormat['lz4'] = 'lz4'
---@field zlib @The zlib format is DEFLATE-compressed data with a small bit of header data. Compresses relatively slowly and decompresses moderately quickly, and has a decent compression ratio.
CompressedDataFormat['zlib'] = 'zlib'
---@field gzip @The gzip format is DEFLATE-compressed data with a slightly larger header than zlib. Since it uses DEFLATE it has the same compression characteristics as the zlib format.
CompressedDataFormat['gzip'] = 'gzip'
---Types of hardware cursors.
---@class CursorType
---@type CursorType
CursorType={}
---@field image @The cursor is using a custom image.
CursorType['image'] = 'image'
---@field arrow @An arrow pointer.
CursorType['arrow'] = 'arrow'
---@field ibeam @An I-beam, normally used when mousing over editable or selectable text.
CursorType['ibeam'] = 'ibeam'
---@field wait @Wait graphic.
CursorType['wait'] = 'wait'
---@field waitarrow @Small wait cursor with an arrow pointer.
CursorType['waitarrow'] = 'waitarrow'
---@field crosshair @Crosshair symbol.
CursorType['crosshair'] = 'crosshair'
---@field sizenwse @Double arrow pointing to the top-left and bottom-right.
CursorType['sizenwse'] = 'sizenwse'
---@field sizenesw @Double arrow pointing to the top-right and bottom-left.
CursorType['sizenesw'] = 'sizenesw'
---@field sizewe @Double arrow pointing left and right.
CursorType['sizewe'] = 'sizewe'
---@field sizens @Double arrow pointing up and down.
CursorType['sizens'] = 'sizens'
---@field sizeall @Four-pointed arrow pointing up, down, left, and right.
CursorType['sizeall'] = 'sizeall'
---@field no @Slashed circle or crossbones.
CursorType['no'] = 'no'
---@field hand @Hand symbol.
CursorType['hand'] = 'hand'
---The types of a Body.
---@class BodyType
---@type BodyType
BodyType={}
---@field static @Static bodies do not move.
BodyType['static'] = 'static'
---@field dynamic @Dynamic bodies collide with all bodies.
BodyType['dynamic'] = 'dynamic'
---@field kinematic @Kinematic bodies only collide with dynamic bodies.
BodyType['kinematic'] = 'kinematic'
---Different types of joints.
---@class JointType
---@type JointType
JointType={}
---@field distance @A DistanceJoint.
JointType['distance'] = 'distance'
---@field gear @A GearJoint.
JointType['gear'] = 'gear'
---@field mouse @A MouseJoint.
JointType['mouse'] = 'mouse'
---@field prismatic @A PrismaticJoint.
JointType['prismatic'] = 'prismatic'
---@field pulley @A PulleyJoint.
JointType['pulley'] = 'pulley'
---@field revolute @A RevoluteJoint.
JointType['revolute'] = 'revolute'
---@field friction @A FrictionJoint.
JointType['friction'] = 'friction'
---@field weld @A WeldJoint.
JointType['weld'] = 'weld'
---@field rope @A RopeJoint.
JointType['rope'] = 'rope'
---The different types of Shapes, as returned by Shape:getType.
---@class ShapeType
---@type ShapeType
ShapeType={}
---@field circle @The Shape is a CircleShape.
ShapeType['circle'] = 'circle'
---@field polygon @The Shape is a PolygonShape.
ShapeType['polygon'] = 'polygon'
---@field edge @The Shape is a EdgeShape.
ShapeType['edge'] = 'edge'
---@field chain @The Shape is a ChainShape.
ShapeType['chain'] = 'chain'
---The basic state of the system's power supply.
---@class PowerState
---@type PowerState
PowerState={}
---@field unknown @Cannot determine power status.
PowerState['unknown'] = 'unknown'
---@field battery @Not plugged in, running on a battery.
PowerState['battery'] = 'battery'
---@field nobattery @Plugged in, no battery available.
PowerState['nobattery'] = 'nobattery'
---@field charging @Plugged in, charging battery.
PowerState['charging'] = 'charging'
---@field charged @Plugged in, battery is fully charged.
PowerState['charged'] = 'charged'
---Types of fullscreen modes.
--- 
--- In normal fullscreen mode, if a window size is used which does not match one of the monitor's supported display modes, the window will be resized to the next largest display mode.
--- 
--- Normal fullscreen mode is sometimes avoided by users because it can cause issues in some window managers and with multi-monitor setups. In OS X it prevents switching to a different program until fullscreen mode is exited. The "desktop" fullscreen mode generally avoids these issues.
---@class FullscreenType
---@type FullscreenType
FullscreenType={}
---@field desktop @Sometimes known as borderless fullscreen windowed mode. A borderless screen-sized window is created which sits on top of all desktop UI elements. The window is automatically resized to match the dimensions of the desktop, and its size cannot be changed.
FullscreenType['desktop'] = 'desktop'
---@field exclusive @Standard exclusive-fullscreen mode. Changes the display mode (actual resolution) of the monitor.
FullscreenType['exclusive'] = 'exclusive'
---Types of message box dialogs. Different types may have slightly different looks.
---@class MessageBoxType
---@type MessageBoxType
MessageBoxType={}
---@field info @Informational dialog.
MessageBoxType['info'] = 'info'
---@field warning @Warning dialog.
MessageBoxType['warning'] = 'warning'
---@field error @Error dialog.
MessageBoxType['error'] = 'error'
