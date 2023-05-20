extern alias System_Runtime_Extensions;
namespace System.Runtime.CompilerServices {
    internal class __BlockReflectionAttribute : Attribute { }
}

namespace Microsoft.Xml.Serialization.GeneratedAssembly {


    [System.Runtime.CompilerServices.__BlockReflection]
    public class XmlSerializationWriter1 : System.Xml.Serialization.XmlSerializationWriter {

        public void Write12_Tile(object o, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs ?? @"";
            WriteStartDocument();
            if (o == null) {
                WriteNullTagLiteral(@"Tile", defaultNamespace);
                return;
            }
            TopLevelElement();
            string namespace1 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            Write10_Tile(@"Tile", namespace1, ((global::Threading_in_C_UWP.Board.Tile)o), true, false, namespace1, @"");
        }

        public void Write13_TileList(object o, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs ?? @"";
            WriteStartDocument();
            if (o == null) {
                WriteNullTagLiteral(@"TileList", defaultNamespace);
                return;
            }
            TopLevelElement();
            string namespace2 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            Write11_TileList(@"TileList", namespace2, ((global::Threading_in_C_UWP.Converters.TileConverter.TileList)o), true, false, namespace2, @"");
        }

        void Write11_TileList(string n, string ns, global::Threading_in_C_UWP.Converters.TileConverter.TileList o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::Threading_in_C_UWP.Converters.TileConverter.TileList)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"TileList", defaultNamespace);
            {
                global::System.Collections.Generic.List<global::Threading_in_C_UWP.Board.Tile> a = (global::System.Collections.Generic.List<global::Threading_in_C_UWP.Board.Tile>)o.@Tiles;
                if (a != null) {
                    for (int ia = 0; ia < ((System.Collections.ICollection)a).Count; ia++) {
                        string namespace3 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
                        Write10_Tile(@"Tile", namespace3, ((global::Threading_in_C_UWP.Board.Tile)a[ia]), false, false, namespace3, @"");
                    }
                }
            }
            WriteEndElement(o);
        }

        void Write10_Tile(string n, string ns, global::Threading_in_C_UWP.Board.Tile o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::Threading_in_C_UWP.Board.Tile)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"Tile", defaultNamespace);
            string namespace4 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            Write9_Placeable(@"Placeable", namespace4, ((global::Threading_in_C_UWP.Board.placeable.Placeable)o.@placeable), false, false, namespace4, @"");
            string namespace5 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"x", namespace5, ((global::System.String)o.@xAsText));
            string namespace6 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"y", namespace6, ((global::System.String)o.@yAsText));
            WriteEndElement(o);
        }

        void Write9_Placeable(string n, string ns, global::Threading_in_C_UWP.Board.placeable.Placeable o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::Threading_in_C_UWP.Board.placeable.Placeable)) {
                }
                else {
                    if (t == typeof(global::Threading_in_C_UWP.Board.placeable.InMovable)) {
                        Write7_InMovable(n, ns,(global::Threading_in_C_UWP.Board.placeable.InMovable)o, isNullable, true);
                        return;
                    }
                    if (t == typeof(global::Threading_in_C_UWP.Board.placeable.Obstacle)) {
                        Write8_Obstacle(n, ns,(global::Threading_in_C_UWP.Board.placeable.Obstacle)o, isNullable, true);
                        return;
                    }
                    if (t == typeof(global::Threading_in_C_UWP.Board.placeable.Moveable)) {
                        Write2_Moveable(n, ns,(global::Threading_in_C_UWP.Board.placeable.Moveable)o, isNullable, true);
                        return;
                    }
                    if (t == typeof(global::Threading_in_C_UWP.Players.Entity)) {
                        Write4_Entity(n, ns,(global::Threading_in_C_UWP.Players.Entity)o, isNullable, true);
                        return;
                    }
                    if (t == typeof(global::Threading_in_C_UWP.Players.Character)) {
                        Write5_Character(n, ns,(global::Threading_in_C_UWP.Players.Character)o, isNullable, true);
                        return;
                    }
                    if (t == typeof(global::Threading_in_C_UWP.Players.Player)) {
                        Write6_Player(n, ns,(global::Threading_in_C_UWP.Players.Player)o, isNullable, true);
                        return;
                    }
                    if (t == typeof(global::Threading_in_C_UWP.Players.Enemy)) {
                        Write3_Enemy(n, ns,(global::Threading_in_C_UWP.Players.Enemy)o, isNullable, true);
                        return;
                    }
                    throw CreateUnknownTypeException(o);
                }
            }
        }

        void Write3_Enemy(string n, string ns, global::Threading_in_C_UWP.Players.Enemy o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::Threading_in_C_UWP.Players.Enemy)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"Enemy", defaultNamespace);
            string namespace7 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"Name", namespace7, ((global::System.String)o.@Name));
            string namespace8 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"Health", namespace8, ((global::System.String)o.@HealthAsText));
            string namespace9 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"Movement", namespace9, ((global::System.String)o.@MovementAsText));
            string namespace10 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"Strength", namespace10, ((global::System.String)o.@StrengthAsText));
            string namespace11 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"Dexterity", namespace11, ((global::System.String)o.@DexterityAsText));
            string namespace12 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"Constitution", namespace12, ((global::System.String)o.@ConstitutionAsText));
            string namespace13 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"Intelligence", namespace13, ((global::System.String)o.@IntelligenceAsText));
            string namespace14 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"Wisdom", namespace14, ((global::System.String)o.@WisdomAsText));
            string namespace15 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"Charisma", namespace15, ((global::System.String)o.@CharismaAsText));
            string namespace16 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"AR", namespace16, ((global::System.String)o.@ARAsText));
            string namespace17 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"BP", namespace17, ((global::System.String)o.@BPAsText));
            string namespace18 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"CR", namespace18, ((global::System.String)o.@CRAsText));
            string namespace19 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"Size", namespace19, ((global::System.String)o.@SizeAsText));
            string namespace20 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"Type", namespace20, ((global::System.String)o.@Type));
            WriteEndElement(o);
        }

        void Write6_Player(string n, string ns, global::Threading_in_C_UWP.Players.Player o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::Threading_in_C_UWP.Players.Player)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"Player", defaultNamespace);
            string namespace21 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"Name", namespace21, ((global::System.String)o.@Name));
            string namespace22 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"Health", namespace22, ((global::System.String)o.@HealthAsText));
            string namespace23 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"Movement", namespace23, ((global::System.String)o.@MovementAsText));
            string namespace24 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"Strength", namespace24, ((global::System.String)o.@StrengthAsText));
            string namespace25 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"Dexterity", namespace25, ((global::System.String)o.@DexterityAsText));
            string namespace26 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"Constitution", namespace26, ((global::System.String)o.@ConstitutionAsText));
            string namespace27 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"Intelligence", namespace27, ((global::System.String)o.@IntelligenceAsText));
            string namespace28 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"Wisdom", namespace28, ((global::System.String)o.@WisdomAsText));
            string namespace29 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"Charisma", namespace29, ((global::System.String)o.@CharismaAsText));
            string namespace30 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"AR", namespace30, ((global::System.String)o.@ARAsText));
            string namespace31 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"BP", namespace31, ((global::System.String)o.@BPAsText));
            string namespace32 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"Class", namespace32, ((global::System.String)o.@Class));
            string namespace33 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementStringRaw(@"PlayerLevel", namespace33, System.Xml.XmlConvert.ToString((global::System.Int32)((global::System.Int32)o.@PlayerLevel)));
            string namespace34 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"PlayerIndex", namespace34, ((global::System.String)o.@PlayerIndexAsText));
            WriteEndElement(o);
        }

        void Write5_Character(string n, string ns, global::Threading_in_C_UWP.Players.Character o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::Threading_in_C_UWP.Players.Character)) {
                }
                else {
                    if (t == typeof(global::Threading_in_C_UWP.Players.Player)) {
                        Write6_Player(n, ns,(global::Threading_in_C_UWP.Players.Player)o, isNullable, true);
                        return;
                    }
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"Character", defaultNamespace);
            string namespace35 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"Name", namespace35, ((global::System.String)o.@Name));
            string namespace36 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"Health", namespace36, ((global::System.String)o.@HealthAsText));
            string namespace37 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"Movement", namespace37, ((global::System.String)o.@MovementAsText));
            string namespace38 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"Strength", namespace38, ((global::System.String)o.@StrengthAsText));
            string namespace39 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"Dexterity", namespace39, ((global::System.String)o.@DexterityAsText));
            string namespace40 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"Constitution", namespace40, ((global::System.String)o.@ConstitutionAsText));
            string namespace41 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"Intelligence", namespace41, ((global::System.String)o.@IntelligenceAsText));
            string namespace42 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"Wisdom", namespace42, ((global::System.String)o.@WisdomAsText));
            string namespace43 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"Charisma", namespace43, ((global::System.String)o.@CharismaAsText));
            string namespace44 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"AR", namespace44, ((global::System.String)o.@ARAsText));
            string namespace45 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"BP", namespace45, ((global::System.String)o.@BPAsText));
            string namespace46 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"Class", namespace46, ((global::System.String)o.@Class));
            WriteEndElement(o);
        }

        void Write4_Entity(string n, string ns, global::Threading_in_C_UWP.Players.Entity o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::Threading_in_C_UWP.Players.Entity)) {
                }
                else {
                    if (t == typeof(global::Threading_in_C_UWP.Players.Character)) {
                        Write5_Character(n, ns,(global::Threading_in_C_UWP.Players.Character)o, isNullable, true);
                        return;
                    }
                    if (t == typeof(global::Threading_in_C_UWP.Players.Player)) {
                        Write6_Player(n, ns,(global::Threading_in_C_UWP.Players.Player)o, isNullable, true);
                        return;
                    }
                    if (t == typeof(global::Threading_in_C_UWP.Players.Enemy)) {
                        Write3_Enemy(n, ns,(global::Threading_in_C_UWP.Players.Enemy)o, isNullable, true);
                        return;
                    }
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"Entity", defaultNamespace);
            string namespace47 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"Name", namespace47, ((global::System.String)o.@Name));
            string namespace48 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"Health", namespace48, ((global::System.String)o.@HealthAsText));
            string namespace49 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"Movement", namespace49, ((global::System.String)o.@MovementAsText));
            string namespace50 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"Strength", namespace50, ((global::System.String)o.@StrengthAsText));
            string namespace51 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"Dexterity", namespace51, ((global::System.String)o.@DexterityAsText));
            string namespace52 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"Constitution", namespace52, ((global::System.String)o.@ConstitutionAsText));
            string namespace53 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"Intelligence", namespace53, ((global::System.String)o.@IntelligenceAsText));
            string namespace54 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"Wisdom", namespace54, ((global::System.String)o.@WisdomAsText));
            string namespace55 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"Charisma", namespace55, ((global::System.String)o.@CharismaAsText));
            string namespace56 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"AR", namespace56, ((global::System.String)o.@ARAsText));
            string namespace57 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"BP", namespace57, ((global::System.String)o.@BPAsText));
            WriteEndElement(o);
        }

        void Write2_Moveable(string n, string ns, global::Threading_in_C_UWP.Board.placeable.Moveable o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::Threading_in_C_UWP.Board.placeable.Moveable)) {
                }
                else {
                    if (t == typeof(global::Threading_in_C_UWP.Players.Entity)) {
                        Write4_Entity(n, ns,(global::Threading_in_C_UWP.Players.Entity)o, isNullable, true);
                        return;
                    }
                    if (t == typeof(global::Threading_in_C_UWP.Players.Character)) {
                        Write5_Character(n, ns,(global::Threading_in_C_UWP.Players.Character)o, isNullable, true);
                        return;
                    }
                    if (t == typeof(global::Threading_in_C_UWP.Players.Player)) {
                        Write6_Player(n, ns,(global::Threading_in_C_UWP.Players.Player)o, isNullable, true);
                        return;
                    }
                    if (t == typeof(global::Threading_in_C_UWP.Players.Enemy)) {
                        Write3_Enemy(n, ns,(global::Threading_in_C_UWP.Players.Enemy)o, isNullable, true);
                        return;
                    }
                    throw CreateUnknownTypeException(o);
                }
            }
        }

        void Write8_Obstacle(string n, string ns, global::Threading_in_C_UWP.Board.placeable.Obstacle o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::Threading_in_C_UWP.Board.placeable.Obstacle)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"Obstacle", defaultNamespace);
            string namespace58 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"type", namespace58, ((global::System.String)o.@type));
            WriteEndElement(o);
        }

        void Write7_InMovable(string n, string ns, global::Threading_in_C_UWP.Board.placeable.InMovable o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::Threading_in_C_UWP.Board.placeable.InMovable)) {
                }
                else {
                    if (t == typeof(global::Threading_in_C_UWP.Board.placeable.Obstacle)) {
                        Write8_Obstacle(n, ns,(global::Threading_in_C_UWP.Board.placeable.Obstacle)o, isNullable, true);
                        return;
                    }
                    throw CreateUnknownTypeException(o);
                }
            }
        }

        protected override void InitCallbacks() {
        }
    }

    [System.Runtime.CompilerServices.__BlockReflection]
    public class XmlSerializationReader1 : System.Xml.Serialization.XmlSerializationReader {

        public object Read12_Tile(string defaultNamespace = null) {
            object o = null;
            Reader.MoveToContent();
            if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                if (((object) Reader.LocalName == (object)id1_Tile && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                    o = Read10_Tile(true, true, defaultNamespace);
                }
                else {
                    throw CreateUnknownNodeException();
                }
            }
            else {
                UnknownNode(null, defaultNamespace ?? @":Tile");
            }
            return (object)o;
        }

        public object Read13_TileList(string defaultNamespace = null) {
            object o = null;
            Reader.MoveToContent();
            if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                if (((object) Reader.LocalName == (object)id3_TileList && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                    o = Read11_TileList(true, true, defaultNamespace);
                }
                else {
                    throw CreateUnknownNodeException();
                }
            }
            else {
                UnknownNode(null, defaultNamespace ?? @":TileList");
            }
            return (object)o;
        }

        global::Threading_in_C_UWP.Converters.TileConverter.TileList Read11_TileList(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id3_TileList && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item))) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::Threading_in_C_UWP.Converters.TileConverter.TileList o;
            o = new global::Threading_in_C_UWP.Converters.TileConverter.TileList();
            if ((object)(o.@Tiles) == null) o.@Tiles = new global::System.Collections.Generic.List<global::Threading_in_C_UWP.Board.Tile>();
            global::System.Collections.Generic.List<global::Threading_in_C_UWP.Board.Tile> a_0 = (global::System.Collections.Generic.List<global::Threading_in_C_UWP.Board.Tile>)o.@Tiles;
            bool[] paramsRead = new bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations0 = 0;
            int readerCount0 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (((object) Reader.LocalName == (object)id1_Tile && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        if ((object)(a_0) == null) Reader.Skip(); else a_0.Add(Read10_Tile(false, true, defaultNamespace));
                    }
                    else {
                        UnknownNode((object)o, @":Tile");
                    }
                }
                else {
                    UnknownNode((object)o, @":Tile");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations0, ref readerCount0);
            }
            ReadEndElement();
            return o;
        }

        global::Threading_in_C_UWP.Board.Tile Read10_Tile(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id1_Tile && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item))) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::Threading_in_C_UWP.Board.Tile o;
            o = new global::Threading_in_C_UWP.Board.Tile();
            bool[] paramsRead = new bool[3];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations1 = 0;
            int readerCount1 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && ((object) Reader.LocalName == (object)id4_Placeable && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        o.@placeable = Read9_Placeable(false, true, defaultNamespace);
                        paramsRead[0] = true;
                    }
                    else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id5_x && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@xAsText = Reader.ReadElementContentAsString();
                        }
                        paramsRead[1] = true;
                    }
                    else if (!paramsRead[2] && ((object) Reader.LocalName == (object)id6_y && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@yAsText = Reader.ReadElementContentAsString();
                        }
                        paramsRead[2] = true;
                    }
                    else {
                        UnknownNode((object)o, @":Placeable, :x, :y");
                    }
                }
                else {
                    UnknownNode((object)o, @":Placeable, :x, :y");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations1, ref readerCount1);
            }
            ReadEndElement();
            return o;
        }

        global::Threading_in_C_UWP.Board.placeable.Placeable Read9_Placeable(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id4_Placeable && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item))) {
            }
            else {
                if (((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id7_InMovable && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item)))
                    return Read7_InMovable(isNullable, false, defaultNamespace);
                if (((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id8_Obstacle && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item)))
                    return Read8_Obstacle(isNullable, false, defaultNamespace);
                if (((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id9_Moveable && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item)))
                    return Read2_Moveable(isNullable, false, defaultNamespace);
                if (((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id10_Entity && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item)))
                    return Read4_Entity(isNullable, false, defaultNamespace);
                if (((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id11_Character && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item)))
                    return Read5_Character(isNullable, false, defaultNamespace);
                if (((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id12_Player && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item)))
                    return Read6_Player(isNullable, false, defaultNamespace);
                if (((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id13_Enemy && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item)))
                    return Read3_Enemy(isNullable, false, defaultNamespace);
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            throw CreateAbstractTypeException(@"Placeable", @"");
        }

        global::Threading_in_C_UWP.Players.Enemy Read3_Enemy(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id13_Enemy && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item))) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::Threading_in_C_UWP.Players.Enemy o;
            o = new global::Threading_in_C_UWP.Players.Enemy();
            bool[] paramsRead = new bool[14];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations2 = 0;
            int readerCount2 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && ((object) Reader.LocalName == (object)id14_Name && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@Name = Reader.ReadElementContentAsString();
                        }
                        paramsRead[0] = true;
                    }
                    else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id15_Health && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@HealthAsText = Reader.ReadElementContentAsString();
                        }
                        paramsRead[1] = true;
                    }
                    else if (!paramsRead[2] && ((object) Reader.LocalName == (object)id16_Movement && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@MovementAsText = Reader.ReadElementContentAsString();
                        }
                        paramsRead[2] = true;
                    }
                    else if (!paramsRead[3] && ((object) Reader.LocalName == (object)id17_Strength && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@StrengthAsText = Reader.ReadElementContentAsString();
                        }
                        paramsRead[3] = true;
                    }
                    else if (!paramsRead[4] && ((object) Reader.LocalName == (object)id18_Dexterity && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@DexterityAsText = Reader.ReadElementContentAsString();
                        }
                        paramsRead[4] = true;
                    }
                    else if (!paramsRead[5] && ((object) Reader.LocalName == (object)id19_Constitution && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@ConstitutionAsText = Reader.ReadElementContentAsString();
                        }
                        paramsRead[5] = true;
                    }
                    else if (!paramsRead[6] && ((object) Reader.LocalName == (object)id20_Intelligence && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@IntelligenceAsText = Reader.ReadElementContentAsString();
                        }
                        paramsRead[6] = true;
                    }
                    else if (!paramsRead[7] && ((object) Reader.LocalName == (object)id21_Wisdom && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@WisdomAsText = Reader.ReadElementContentAsString();
                        }
                        paramsRead[7] = true;
                    }
                    else if (!paramsRead[8] && ((object) Reader.LocalName == (object)id22_Charisma && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@CharismaAsText = Reader.ReadElementContentAsString();
                        }
                        paramsRead[8] = true;
                    }
                    else if (!paramsRead[9] && ((object) Reader.LocalName == (object)id23_AR && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@ARAsText = Reader.ReadElementContentAsString();
                        }
                        paramsRead[9] = true;
                    }
                    else if (!paramsRead[10] && ((object) Reader.LocalName == (object)id24_BP && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@BPAsText = Reader.ReadElementContentAsString();
                        }
                        paramsRead[10] = true;
                    }
                    else if (!paramsRead[11] && ((object) Reader.LocalName == (object)id25_CR && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@CRAsText = Reader.ReadElementContentAsString();
                        }
                        paramsRead[11] = true;
                    }
                    else if (!paramsRead[12] && ((object) Reader.LocalName == (object)id26_Size && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@SizeAsText = Reader.ReadElementContentAsString();
                        }
                        paramsRead[12] = true;
                    }
                    else if (!paramsRead[13] && ((object) Reader.LocalName == (object)id27_Type && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@Type = Reader.ReadElementContentAsString();
                        }
                        paramsRead[13] = true;
                    }
                    else {
                        UnknownNode((object)o, @":Name, :Health, :Movement, :Strength, :Dexterity, :Constitution, :Intelligence, :Wisdom, :Charisma, :AR, :BP, :CR, :Size, :Type");
                    }
                }
                else {
                    UnknownNode((object)o, @":Name, :Health, :Movement, :Strength, :Dexterity, :Constitution, :Intelligence, :Wisdom, :Charisma, :AR, :BP, :CR, :Size, :Type");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations2, ref readerCount2);
            }
            ReadEndElement();
            return o;
        }

        global::Threading_in_C_UWP.Players.Player Read6_Player(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id12_Player && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item))) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::Threading_in_C_UWP.Players.Player o;
            o = new global::Threading_in_C_UWP.Players.Player();
            bool[] paramsRead = new bool[14];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations3 = 0;
            int readerCount3 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && ((object) Reader.LocalName == (object)id14_Name && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@Name = Reader.ReadElementContentAsString();
                        }
                        paramsRead[0] = true;
                    }
                    else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id15_Health && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@HealthAsText = Reader.ReadElementContentAsString();
                        }
                        paramsRead[1] = true;
                    }
                    else if (!paramsRead[2] && ((object) Reader.LocalName == (object)id16_Movement && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@MovementAsText = Reader.ReadElementContentAsString();
                        }
                        paramsRead[2] = true;
                    }
                    else if (!paramsRead[3] && ((object) Reader.LocalName == (object)id17_Strength && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@StrengthAsText = Reader.ReadElementContentAsString();
                        }
                        paramsRead[3] = true;
                    }
                    else if (!paramsRead[4] && ((object) Reader.LocalName == (object)id18_Dexterity && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@DexterityAsText = Reader.ReadElementContentAsString();
                        }
                        paramsRead[4] = true;
                    }
                    else if (!paramsRead[5] && ((object) Reader.LocalName == (object)id19_Constitution && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@ConstitutionAsText = Reader.ReadElementContentAsString();
                        }
                        paramsRead[5] = true;
                    }
                    else if (!paramsRead[6] && ((object) Reader.LocalName == (object)id20_Intelligence && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@IntelligenceAsText = Reader.ReadElementContentAsString();
                        }
                        paramsRead[6] = true;
                    }
                    else if (!paramsRead[7] && ((object) Reader.LocalName == (object)id21_Wisdom && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@WisdomAsText = Reader.ReadElementContentAsString();
                        }
                        paramsRead[7] = true;
                    }
                    else if (!paramsRead[8] && ((object) Reader.LocalName == (object)id22_Charisma && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@CharismaAsText = Reader.ReadElementContentAsString();
                        }
                        paramsRead[8] = true;
                    }
                    else if (!paramsRead[9] && ((object) Reader.LocalName == (object)id23_AR && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@ARAsText = Reader.ReadElementContentAsString();
                        }
                        paramsRead[9] = true;
                    }
                    else if (!paramsRead[10] && ((object) Reader.LocalName == (object)id24_BP && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@BPAsText = Reader.ReadElementContentAsString();
                        }
                        paramsRead[10] = true;
                    }
                    else if (!paramsRead[11] && ((object) Reader.LocalName == (object)id28_Class && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@Class = Reader.ReadElementContentAsString();
                        }
                        paramsRead[11] = true;
                    }
                    else if (!paramsRead[12] && ((object) Reader.LocalName == (object)id29_PlayerLevel && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@PlayerLevel = System.Xml.XmlConvert.ToInt32(Reader.ReadElementContentAsString());
                        }
                        paramsRead[12] = true;
                    }
                    else if (!paramsRead[13] && ((object) Reader.LocalName == (object)id30_PlayerIndex && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@PlayerIndexAsText = Reader.ReadElementContentAsString();
                        }
                        paramsRead[13] = true;
                    }
                    else {
                        UnknownNode((object)o, @":Name, :Health, :Movement, :Strength, :Dexterity, :Constitution, :Intelligence, :Wisdom, :Charisma, :AR, :BP, :Class, :PlayerLevel, :PlayerIndex");
                    }
                }
                else {
                    UnknownNode((object)o, @":Name, :Health, :Movement, :Strength, :Dexterity, :Constitution, :Intelligence, :Wisdom, :Charisma, :AR, :BP, :Class, :PlayerLevel, :PlayerIndex");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations3, ref readerCount3);
            }
            ReadEndElement();
            return o;
        }

        global::Threading_in_C_UWP.Players.Character Read5_Character(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id11_Character && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item))) {
            }
            else {
                if (((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id12_Player && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item)))
                    return Read6_Player(isNullable, false, defaultNamespace);
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::Threading_in_C_UWP.Players.Character o;
            o = new global::Threading_in_C_UWP.Players.Character();
            bool[] paramsRead = new bool[12];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations4 = 0;
            int readerCount4 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && ((object) Reader.LocalName == (object)id14_Name && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@Name = Reader.ReadElementContentAsString();
                        }
                        paramsRead[0] = true;
                    }
                    else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id15_Health && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@HealthAsText = Reader.ReadElementContentAsString();
                        }
                        paramsRead[1] = true;
                    }
                    else if (!paramsRead[2] && ((object) Reader.LocalName == (object)id16_Movement && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@MovementAsText = Reader.ReadElementContentAsString();
                        }
                        paramsRead[2] = true;
                    }
                    else if (!paramsRead[3] && ((object) Reader.LocalName == (object)id17_Strength && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@StrengthAsText = Reader.ReadElementContentAsString();
                        }
                        paramsRead[3] = true;
                    }
                    else if (!paramsRead[4] && ((object) Reader.LocalName == (object)id18_Dexterity && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@DexterityAsText = Reader.ReadElementContentAsString();
                        }
                        paramsRead[4] = true;
                    }
                    else if (!paramsRead[5] && ((object) Reader.LocalName == (object)id19_Constitution && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@ConstitutionAsText = Reader.ReadElementContentAsString();
                        }
                        paramsRead[5] = true;
                    }
                    else if (!paramsRead[6] && ((object) Reader.LocalName == (object)id20_Intelligence && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@IntelligenceAsText = Reader.ReadElementContentAsString();
                        }
                        paramsRead[6] = true;
                    }
                    else if (!paramsRead[7] && ((object) Reader.LocalName == (object)id21_Wisdom && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@WisdomAsText = Reader.ReadElementContentAsString();
                        }
                        paramsRead[7] = true;
                    }
                    else if (!paramsRead[8] && ((object) Reader.LocalName == (object)id22_Charisma && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@CharismaAsText = Reader.ReadElementContentAsString();
                        }
                        paramsRead[8] = true;
                    }
                    else if (!paramsRead[9] && ((object) Reader.LocalName == (object)id23_AR && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@ARAsText = Reader.ReadElementContentAsString();
                        }
                        paramsRead[9] = true;
                    }
                    else if (!paramsRead[10] && ((object) Reader.LocalName == (object)id24_BP && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@BPAsText = Reader.ReadElementContentAsString();
                        }
                        paramsRead[10] = true;
                    }
                    else if (!paramsRead[11] && ((object) Reader.LocalName == (object)id28_Class && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@Class = Reader.ReadElementContentAsString();
                        }
                        paramsRead[11] = true;
                    }
                    else {
                        UnknownNode((object)o, @":Name, :Health, :Movement, :Strength, :Dexterity, :Constitution, :Intelligence, :Wisdom, :Charisma, :AR, :BP, :Class");
                    }
                }
                else {
                    UnknownNode((object)o, @":Name, :Health, :Movement, :Strength, :Dexterity, :Constitution, :Intelligence, :Wisdom, :Charisma, :AR, :BP, :Class");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations4, ref readerCount4);
            }
            ReadEndElement();
            return o;
        }

        global::Threading_in_C_UWP.Players.Entity Read4_Entity(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id10_Entity && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item))) {
            }
            else {
                if (((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id11_Character && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item)))
                    return Read5_Character(isNullable, false, defaultNamespace);
                if (((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id12_Player && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item)))
                    return Read6_Player(isNullable, false, defaultNamespace);
                if (((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id13_Enemy && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item)))
                    return Read3_Enemy(isNullable, false, defaultNamespace);
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::Threading_in_C_UWP.Players.Entity o;
            o = new global::Threading_in_C_UWP.Players.Entity();
            bool[] paramsRead = new bool[11];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations5 = 0;
            int readerCount5 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && ((object) Reader.LocalName == (object)id14_Name && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@Name = Reader.ReadElementContentAsString();
                        }
                        paramsRead[0] = true;
                    }
                    else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id15_Health && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@HealthAsText = Reader.ReadElementContentAsString();
                        }
                        paramsRead[1] = true;
                    }
                    else if (!paramsRead[2] && ((object) Reader.LocalName == (object)id16_Movement && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@MovementAsText = Reader.ReadElementContentAsString();
                        }
                        paramsRead[2] = true;
                    }
                    else if (!paramsRead[3] && ((object) Reader.LocalName == (object)id17_Strength && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@StrengthAsText = Reader.ReadElementContentAsString();
                        }
                        paramsRead[3] = true;
                    }
                    else if (!paramsRead[4] && ((object) Reader.LocalName == (object)id18_Dexterity && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@DexterityAsText = Reader.ReadElementContentAsString();
                        }
                        paramsRead[4] = true;
                    }
                    else if (!paramsRead[5] && ((object) Reader.LocalName == (object)id19_Constitution && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@ConstitutionAsText = Reader.ReadElementContentAsString();
                        }
                        paramsRead[5] = true;
                    }
                    else if (!paramsRead[6] && ((object) Reader.LocalName == (object)id20_Intelligence && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@IntelligenceAsText = Reader.ReadElementContentAsString();
                        }
                        paramsRead[6] = true;
                    }
                    else if (!paramsRead[7] && ((object) Reader.LocalName == (object)id21_Wisdom && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@WisdomAsText = Reader.ReadElementContentAsString();
                        }
                        paramsRead[7] = true;
                    }
                    else if (!paramsRead[8] && ((object) Reader.LocalName == (object)id22_Charisma && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@CharismaAsText = Reader.ReadElementContentAsString();
                        }
                        paramsRead[8] = true;
                    }
                    else if (!paramsRead[9] && ((object) Reader.LocalName == (object)id23_AR && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@ARAsText = Reader.ReadElementContentAsString();
                        }
                        paramsRead[9] = true;
                    }
                    else if (!paramsRead[10] && ((object) Reader.LocalName == (object)id24_BP && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@BPAsText = Reader.ReadElementContentAsString();
                        }
                        paramsRead[10] = true;
                    }
                    else {
                        UnknownNode((object)o, @":Name, :Health, :Movement, :Strength, :Dexterity, :Constitution, :Intelligence, :Wisdom, :Charisma, :AR, :BP");
                    }
                }
                else {
                    UnknownNode((object)o, @":Name, :Health, :Movement, :Strength, :Dexterity, :Constitution, :Intelligence, :Wisdom, :Charisma, :AR, :BP");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations5, ref readerCount5);
            }
            ReadEndElement();
            return o;
        }

        global::Threading_in_C_UWP.Board.placeable.Moveable Read2_Moveable(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id9_Moveable && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item))) {
            }
            else {
                if (((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id10_Entity && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item)))
                    return Read4_Entity(isNullable, false, defaultNamespace);
                if (((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id11_Character && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item)))
                    return Read5_Character(isNullable, false, defaultNamespace);
                if (((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id12_Player && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item)))
                    return Read6_Player(isNullable, false, defaultNamespace);
                if (((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id13_Enemy && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item)))
                    return Read3_Enemy(isNullable, false, defaultNamespace);
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            throw CreateAbstractTypeException(@"Moveable", @"");
        }

        global::Threading_in_C_UWP.Board.placeable.Obstacle Read8_Obstacle(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id8_Obstacle && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item))) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::Threading_in_C_UWP.Board.placeable.Obstacle o;
            o = new global::Threading_in_C_UWP.Board.placeable.Obstacle();
            bool[] paramsRead = new bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations6 = 0;
            int readerCount6 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && ((object) Reader.LocalName == (object)id31_type && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@type = Reader.ReadElementContentAsString();
                        }
                        paramsRead[0] = true;
                    }
                    else {
                        UnknownNode((object)o, @":type");
                    }
                }
                else {
                    UnknownNode((object)o, @":type");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations6, ref readerCount6);
            }
            ReadEndElement();
            return o;
        }

        global::Threading_in_C_UWP.Board.placeable.InMovable Read7_InMovable(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id7_InMovable && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item))) {
            }
            else {
                if (((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id8_Obstacle && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item)))
                    return Read8_Obstacle(isNullable, false, defaultNamespace);
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            throw CreateAbstractTypeException(@"InMovable", @"");
        }

        protected override void InitCallbacks() {
        }

        string id9_Moveable;
        string id18_Dexterity;
        string id12_Player;
        string id6_y;
        string id28_Class;
        string id10_Entity;
        string id16_Movement;
        string id1_Tile;
        string id24_BP;
        string id11_Character;
        string id19_Constitution;
        string id3_TileList;
        string id15_Health;
        string id13_Enemy;
        string id7_InMovable;
        string id2_Item;
        string id4_Placeable;
        string id30_PlayerIndex;
        string id27_Type;
        string id17_Strength;
        string id14_Name;
        string id26_Size;
        string id29_PlayerLevel;
        string id22_Charisma;
        string id20_Intelligence;
        string id5_x;
        string id21_Wisdom;
        string id8_Obstacle;
        string id31_type;
        string id23_AR;
        string id25_CR;

        protected override void InitIDs() {
            id9_Moveable = Reader.NameTable.Add(@"Moveable");
            id18_Dexterity = Reader.NameTable.Add(@"Dexterity");
            id12_Player = Reader.NameTable.Add(@"Player");
            id6_y = Reader.NameTable.Add(@"y");
            id28_Class = Reader.NameTable.Add(@"Class");
            id10_Entity = Reader.NameTable.Add(@"Entity");
            id16_Movement = Reader.NameTable.Add(@"Movement");
            id1_Tile = Reader.NameTable.Add(@"Tile");
            id24_BP = Reader.NameTable.Add(@"BP");
            id11_Character = Reader.NameTable.Add(@"Character");
            id19_Constitution = Reader.NameTable.Add(@"Constitution");
            id3_TileList = Reader.NameTable.Add(@"TileList");
            id15_Health = Reader.NameTable.Add(@"Health");
            id13_Enemy = Reader.NameTable.Add(@"Enemy");
            id7_InMovable = Reader.NameTable.Add(@"InMovable");
            id2_Item = Reader.NameTable.Add(@"");
            id4_Placeable = Reader.NameTable.Add(@"Placeable");
            id30_PlayerIndex = Reader.NameTable.Add(@"PlayerIndex");
            id27_Type = Reader.NameTable.Add(@"Type");
            id17_Strength = Reader.NameTable.Add(@"Strength");
            id14_Name = Reader.NameTable.Add(@"Name");
            id26_Size = Reader.NameTable.Add(@"Size");
            id29_PlayerLevel = Reader.NameTable.Add(@"PlayerLevel");
            id22_Charisma = Reader.NameTable.Add(@"Charisma");
            id20_Intelligence = Reader.NameTable.Add(@"Intelligence");
            id5_x = Reader.NameTable.Add(@"x");
            id21_Wisdom = Reader.NameTable.Add(@"Wisdom");
            id8_Obstacle = Reader.NameTable.Add(@"Obstacle");
            id31_type = Reader.NameTable.Add(@"type");
            id23_AR = Reader.NameTable.Add(@"AR");
            id25_CR = Reader.NameTable.Add(@"CR");
        }
    }

    [System.Runtime.CompilerServices.__BlockReflection]
    public abstract class XmlSerializer1 : System.Xml.Serialization.XmlSerializer {
        protected override System.Xml.Serialization.XmlSerializationReader CreateReader() {
            return new XmlSerializationReader1();
        }
        protected override System.Xml.Serialization.XmlSerializationWriter CreateWriter() {
            return new XmlSerializationWriter1();
        }
    }

    [System.Runtime.CompilerServices.__BlockReflection]
    public sealed class TileSerializer : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"Tile", this.DefaultNamespace ?? @"");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write12_Tile(objectToSerialize, this.DefaultNamespace, @"");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read12_Tile(this.DefaultNamespace);
        }
    }

    [System.Runtime.CompilerServices.__BlockReflection]
    public sealed class TileListSerializer : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"TileList", this.DefaultNamespace ?? @"");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write13_TileList(objectToSerialize, this.DefaultNamespace, @"");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read13_TileList(this.DefaultNamespace);
        }
    }

    [System.Runtime.CompilerServices.__BlockReflection]
    public class XmlSerializerContract : global::System.Xml.Serialization.XmlSerializerImplementation {
        public override global::System.Xml.Serialization.XmlSerializationReader Reader { get { return new XmlSerializationReader1(); } }
        public override global::System.Xml.Serialization.XmlSerializationWriter Writer { get { return new XmlSerializationWriter1(); } }
        System_Runtime_Extensions::System.Collections.Hashtable readMethods = null;
        public override System_Runtime_Extensions::System.Collections.Hashtable ReadMethods {
            get {
                if (readMethods == null) {
                    System_Runtime_Extensions::System.Collections.Hashtable _tmp = new System_Runtime_Extensions::System.Collections.Hashtable();
                    _tmp[@"Threading_in_C_UWP.Board.Tile::"] = @"Read12_Tile";
                    _tmp[@"Threading_in_C_UWP.Converters.TileConverter+TileList::TileList:True:"] = @"Read13_TileList";
                    if (readMethods == null) readMethods = _tmp;
                }
                return readMethods;
            }
        }
        System_Runtime_Extensions::System.Collections.Hashtable writeMethods = null;
        public override System_Runtime_Extensions::System.Collections.Hashtable WriteMethods {
            get {
                if (writeMethods == null) {
                    System_Runtime_Extensions::System.Collections.Hashtable _tmp = new System_Runtime_Extensions::System.Collections.Hashtable();
                    _tmp[@"Threading_in_C_UWP.Board.Tile::"] = @"Write12_Tile";
                    _tmp[@"Threading_in_C_UWP.Converters.TileConverter+TileList::TileList:True:"] = @"Write13_TileList";
                    if (writeMethods == null) writeMethods = _tmp;
                }
                return writeMethods;
            }
        }
        System_Runtime_Extensions::System.Collections.Hashtable typedSerializers = null;
        public override System_Runtime_Extensions::System.Collections.Hashtable TypedSerializers {
            get {
                if (typedSerializers == null) {
                    System_Runtime_Extensions::System.Collections.Hashtable _tmp = new System_Runtime_Extensions::System.Collections.Hashtable();
                    _tmp.Add(@"Threading_in_C_UWP.Converters.TileConverter+TileList::TileList:True:", new TileListSerializer());
                    _tmp.Add(@"Threading_in_C_UWP.Board.Tile::", new TileSerializer());
                    if (typedSerializers == null) typedSerializers = _tmp;
                }
                return typedSerializers;
            }
        }
        public override System.Boolean CanSerialize(System.Type type) {
            if (type == typeof(global::Threading_in_C_UWP.Board.Tile)) return true;
            if (type == typeof(global::Threading_in_C_UWP.Converters.TileConverter.TileList)) return true;
            if (type == typeof(global::System.Reflection.TypeInfo)) return true;
            return false;
        }
        public override System.Xml.Serialization.XmlSerializer GetSerializer(System.Type type) {
            if (type == typeof(global::Threading_in_C_UWP.Board.Tile)) return new TileSerializer();
            if (type == typeof(global::Threading_in_C_UWP.Converters.TileConverter.TileList)) return new TileListSerializer();
            return null;
        }
        public static global::System.Xml.Serialization.XmlSerializerImplementation GetXmlSerializerContract() { return new XmlSerializerContract(); }
    }

    [System.Runtime.CompilerServices.__BlockReflection]
    public static class ActivatorHelper {
        public static object CreateInstance(System.Type type) {
            System.Reflection.TypeInfo ti = System.Reflection.IntrospectionExtensions.GetTypeInfo(type);
            foreach (System.Reflection.ConstructorInfo ci in ti.DeclaredConstructors) {
                if (!ci.IsStatic && ci.GetParameters().Length == 0) {
                    return ci.Invoke(null);
                }
            }
            return System.Activator.CreateInstance(type);
        }
    }
}
