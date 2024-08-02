
using UnityEngine;
using UnityEngine.UI;

public class RepeatRollerConveyor : ComponentBehavior
{
   [SerializeField] protected RawImage rawImage;
   [SerializeField] protected float scrollSpeed = -0.05f; 
   [SerializeField] protected Vector2 tiling = new Vector2(1, 1);
   protected override void LoadComponent()
   {
      base.LoadComponent();
      this.LoadRawImage();
   }

   protected virtual void LoadRawImage()
   {
      if(rawImage != null) return;
      rawImage = transform.GetComponent<RawImage>();
      if (rawImage != null)
         Debug.Log(transform.name + " Load Raw Image successful");
   }

   protected override void ResetValue()
   {
      base.ResetValue();
      this.ResetScrollSpeed();
      this.ResetTiling();
   }

   protected virtual void ResetScrollSpeed()
   {
      this.scrollSpeed = -0.05f;
   }

   protected virtual void ResetTiling()
   {
      tiling = new Vector2(1, 1);
   }

   protected override void Start()
   {
      if (rawImage)
      {
         rawImage.uvRect = new Rect(0, 0, tiling.x, tiling.y);
      }
   }

   private void Update()
   {
      if (rawImage)
      {
         Rect uvRect = rawImage.uvRect;
         uvRect.y += scrollSpeed * Time.deltaTime; 
         rawImage.uvRect = uvRect;
      }
   }
}
