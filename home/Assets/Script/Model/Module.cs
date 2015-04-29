using UnityEngine;
using System.Collections;

/// <summary>
/// Module.
/// </summary>
public class Module : MonoBehaviour {

	private int id;

	/// <summary>
	/// Gets or sets the identifier.
	/// </summary>
	/// <value>The identifier.</value>
	public int Id {
		get {
			return id;
		}
		set {
			id = value;
		}
	}

	private string no;

	/// <summary>
	/// Gets or sets the no.
	/// </summary>
	/// <value>The no.</value>
	public string No {
		get {
			return no;
		}
		set {
			no = value;
		}
	}

	private string moduleName;
	/// <summary>
	/// Gets or sets the name of the module.
	/// </summary>
	/// <value>The name of the module.</value>
	public string ModuleName {
		get {
			return moduleName;
		}
		set {
			moduleName = value;
		}
	}
	private string description;
	/// <summary>
	/// Gets or sets the description.
	/// </summary>
	/// <value>The description.</value>
	public string Description {
		get {
			return description;
		}
		set {
			description = value;
		}
	}

	private string apkName;
	/// <summary>
	/// Gets or sets the name of the apk.
	/// </summary>
	/// <value>The name of the apk.</value>
	public string ApkName {
		get {
			return apkName;
		}
		set {
			apkName = value;
		}
	}
}
