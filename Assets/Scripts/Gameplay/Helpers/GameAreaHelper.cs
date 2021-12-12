using UnityEngine;

namespace Gameplay.Helpers
{
    public static class GameAreaHelper
    {
        private static GameAreaBounds _bounds;
        
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
            _bounds = new GameAreaBounds(topBound, bottomBound, leftBound, rightBound);
        }

        public static bool FitInGameplayBounds(Vector3 objectPosition, Bounds objectBounds)
        {
            return (objectPosition.x + objectBounds.extents.x < _bounds.RightBound)
                   && (objectPosition.x - objectBounds.extents.x > _bounds.LeftBound)
                   && (objectPosition.y + objectBounds.extents.y < _bounds.TopBound)
                   && (objectPosition.y - objectBounds.extents.y > _bounds.BottomBound);
        }

        public static bool IsInGameplayArea(Bounds objectBounds)
        {
            return (objectBounds.center.x - objectBounds.extents.x < _bounds.RightBound)
                   && (objectBounds.center.x + objectBounds.extents.x > _bounds.LeftBound)
                   && (objectBounds.center.y - objectBounds.extents.y < _bounds.TopBound)
                   && (objectBounds.center.y + objectBounds.extents.y > _bounds.BottomBound);
        }
        
        private struct GameAreaBounds
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
