<!-- default file list -->
*Files to look at*:

* [ReadOnlyCollectionWrapper.cs](./CS/ReadOnlyCollectionWrapper/ReadOnlyCollectionWrapper.cs) (VB: [ReadOnlyCollectionWrapper.vb](./VB/ReadOnlyCollectionWrapper/ReadOnlyCollectionWrapper.vb))
<!-- default file list end -->
# How to make unbound columns editable when the GridView is bound to the read only data source


<p>This example is a workaround to the <a href="https://www.devexpress.com/Support/Center/p/AS4098">Make the unbound columns editable even if the underlying data source's IBindingList.AllowEdit property retrieves false </a>suggestion. XtraGrid architecture does not allow us to implement this suggestion without rewriting a lot of code, and introducing breaking changes. We decided to create a wrapper class that can be used when it is necessary to enable editing the unbound columns.</p>

<br/>


