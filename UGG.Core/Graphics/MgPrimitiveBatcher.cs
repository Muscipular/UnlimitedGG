using System;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MgWheels
{
    public class MgPrimitiveBatcher : PrimitiveBatcherBase<VertexPositionColorTexture, Matrix, Texture2D>
    {
        private readonly GraphicsDevice _graphicsDevice;
        private readonly SpriteBatch _spriteBatch;

        private readonly BasicEffect _basicEffect;

        private readonly VertexBuffer _vb;
        private readonly IndexBuffer _ib;

        public Texture2D BlankTexture { get; }

        public MgPrimitiveBatcher(GraphicsDevice gd)
        {
            _graphicsDevice = gd ?? throw new ArgumentNullException(nameof(gd));

            _spriteBatch = new SpriteBatch(gd);
            _basicEffect = new BasicEffect(gd)
            {
                VertexColorEnabled = true,
                LightingEnabled = false,
                TextureEnabled = true,
                FogEnabled = false,
            };

            BlankTexture = new Texture2D(gd, 1, 1);
            BlankTexture.SetData(new[] {Color.White.PackedValue});
            Texture = BlankTexture;

            var viewport = gd.Viewport;
            TransformMatrix = Matrix.CreateOrthographicOffCenter(0, viewport.Width, viewport.Height, 0, 0, 1);

            _vb = new VertexBuffer(gd, VertexPositionColorTexture.VertexDeclaration, DefaultMaxVertices, BufferUsage.WriteOnly);
            _ib = new IndexBuffer(gd, IndexElementSize.ThirtyTwoBits, DefaultMaxVertices, BufferUsage.WriteOnly);
        }

        protected override VertexPositionColorTexture CreateVertex(Vector2 p, Vector2 uv, Color color)
        {
            return new VertexPositionColorTexture(new Vector3(p.X, p.Y, 0), new Color(color.PackedValue), new Vector2(uv.X, uv.Y));
        }

        protected override void TransformVertexPosition(ref VertexPositionColorTexture v, Matrix transform)
        {
            v.Position = Vector3.Transform(v.Position, transform);
        }

        protected override void SetTexture(Texture2D texture)
        {
            if (texture == null)
                throw new ArgumentNullException(nameof(texture));
            if (texture != _basicEffect.Texture)
                _basicEffect.Texture = texture;
        }

        protected override void BeginFlush(VertexPositionColorTexture[] vertices, int vertexCount, int[] indices, int indexCount)
        {
            _graphicsDevice.BlendState = BlendState.NonPremultiplied;
            _graphicsDevice.DepthStencilState = DepthStencilState.None;
            _graphicsDevice.RasterizerState = RasterizerState.CullNone;
            _graphicsDevice.SamplerStates[0] = SamplerState.LinearWrap;

            _vb.SetData(vertices, 0, vertexCount);
            _ib.SetData(indices, 0, indexCount);
            _graphicsDevice.SetVertexBuffer(_vb);
            _graphicsDevice.Indices = _ib;
        }

        protected override void DrawBatch(int vertexCount, int indexOffset, int indexCount)
        {
            _basicEffect.CurrentTechnique.Passes[0].Apply();
            _graphicsDevice.DrawIndexedPrimitives(
                PrimitiveType.TriangleList,
                0, indexOffset, indexCount / 3);
        }
    }
}