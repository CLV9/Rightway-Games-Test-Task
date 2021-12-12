using UnityEngine;

namespace Gameplay.Helpers
{
    public static class GameAreaHelper
    {
        public static GameAreaBounds Bounds { get; private set; }
        
        static GameAreaHelper()
        {
            CalculateBounds();
        }

        private static void CalculateBounds()
        {
            var camera = Camera.main;
            var camHalfHeight = camera.orthographicSize;
            var camHalfWidth = camHalfHeight * camera.aspect;
            var camPos = camera.transform.position;
            var topBound = camPos.y + camHalfHeight;
            var bottomBound = camPos.y - camHalfHeight;
            var leftBound = camPos.x - camHalfWidth;
            var rightBound = camPos.x + camHalfWidth;
            Bounds = new GameAreaBounds(topBound, bottomBound, leftBound, rightBound);
        }

        public static bool IsInGameplayArea(Bounds objectBounds)
        {
            return (objectBounds.center.x - objectBounds.extents.x < Bounds.RightBound)
                   && (objectBounds.center.x + objectBounds.extents.x > Bounds.LeftBound)
                   && (objectBounds.center.y - objectBounds.extents.y < Bounds.TopBound)
                   && (objectBounds.center.y + objectBounds.extents.y > Bounds.BottomBound);
        }
        
        public struct GameAreaBounds
        {
            public float TopBound { get; set; }
            public float BottomBound { get; set; }
            public float LeftBound { get; set; }
            public float RightBound { get; set; }

            public GameAreaBounds(float topBound, float bottomBound, float leftBound, float rightBound)
            {
                TopBound = topBound;
                BottomBound = bottomBound;
                LeftBound = leftBound;
                RightBound = rightBound;
            }
        }
    }
}
