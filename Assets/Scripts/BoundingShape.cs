using UnityEngine;
using System.Collections;

/// <summary>
/// Logic for the bounding shape surrounding the logical unit.
/// Individual soldiers attempt to stay within this bounding shape.
/// </summary>
public class BoundingShape : MonoBehaviour
{
	// essentially we want the bounding shape to be flat
	private float y_size = 0.01f;

	// bounding data
	public enum BOUNDING_SHAPE {RECTANGULAR, CIRCULAR};
	public BOUNDING_SHAPE shape = BOUNDING_SHAPE.RECTANGULAR;
	// vector to corner of rectangle, or point on circle
	public Vector2 shape_corner = new Vector2(5, 2);
	
	// distance between border of shape and where soldiers should place themselves
	// if they desire to be close to the boundary
	public float padding = 1.0f;

	void Start ()
	{
	}
	
	public void ModifyShape (BOUNDING_SHAPE aShape, float x, float y)
	{
		shape = aShape;
		shape_corner.x = x + this.padding;
		shape_corner.y = y + this.padding;
		// scale in the x and y because the quad we draw on is
		this.transform.localScale = new Vector3( shape_corner.x*2, y_size, shape_corner.y*2 );
	}
	
	public float GetPaddedCornerX()
	{
		return shape_corner.x - padding;
	}
	
	public float GetPaddedCornerY()
	{
		return shape_corner.y - padding;
	}
	
}

