/*
YUI 3.12.0 (build 8655935)
Copyright 2013 Yahoo! Inc. All rights reserved.
Licensed under the BSD License.
http://yuilibrary.com/license/
*/

YUI.add("tree-labelable",function(e,t){function n(){}function r(e,t){this._serializable=this._serializable.concat("label"),"label"in t&&(this.label=t.label)}n.prototype={initializer:function(){this.nodeExtensions=this.nodeExtensions.concat(e.Tree.Node.Labelable)}},e.Tree.Labelable=n,r.prototype={label:""},e.Tree.Node.Labelable=r},"3.12.0",{requires:["tree"]});
