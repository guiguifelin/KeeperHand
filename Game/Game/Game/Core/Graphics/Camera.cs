using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game
{
    public class Camera
    {
        // Fields.
        #region Fields

        private Viewport viewport;
        private Matrix transform;
        private float zoomX = 0;
        private float zoomY = 0;

        #endregion

        // Constructor.

        public Camera(Viewport viewport)
        {
            this.viewport = viewport;
        }

        // Get & Set.
        public Matrix Transform
        {
            get { return transform; }
        }

        // Update.

        public void Update()
        {
            if (viewport.Width != 1240 && viewport.Height != 720)
            {
                zoomX = viewport.Width / 1240;
                zoomY = viewport.Height / 720;
            }
            transform = Matrix.CreateTranslation(new Vector3(zoomX, zoomY, 0) * new Vector3(viewport.Width / 2, viewport.Height / 2, 0));
        }
    }
}
