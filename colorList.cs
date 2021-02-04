using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorList : MonoBehaviour
{
    //This Class is a library of 455 colors and their RGB pairings, coded in a switch case.
    //Simply pass in a valid string and it will return the RGBs needed to create a new Color32() struct.
    //Possible improvment may be to have it work in reverse, accepting RGBs and returning names (uneccessary but plausible)

    public byte[] RGBtriples;

    void Start()
    {
        RGBtriples = new byte[3];
    }

    public bool validColorName(string name)
    {
        RGBtriples = new byte[3] { 0, 0, 0 };

        switch (name)
        {

            case "aliceblue":
                RGBtriples = new byte[3] { 240, 248, 255 };
                return true;
            case "antiquewhite":
                RGBtriples = new byte[3] { 250, 235, 215 };
                return true;
            case "antiquewhite1":
                RGBtriples = new byte[3] { 255, 239, 219 };
                return true;
            case "antiquewhite2":
                RGBtriples = new byte[3] { 238, 223, 204 };
                return true;
            case "antiquewhite3":
                RGBtriples = new byte[3] { 205, 192, 176 };
                return true;
            case "antiquewhite4":
                RGBtriples = new byte[3] { 139, 131, 120 };
                return true;
            case "aquamarine":
                RGBtriples = new byte[3] { 127, 255, 212 };
                return true;
            case "aquamarine1":
                RGBtriples = new byte[3] { 127, 255, 212 };
                return true;
            case "aquamarine2":
                RGBtriples = new byte[3] { 118, 238, 198 };
                return true;
            case "aquamarine3":
                RGBtriples = new byte[3] { 102, 205, 170 };
                return true;
            case "aquamarine4":
                RGBtriples = new byte[3] { 69, 139, 116 };
                return true;
            case "azure":
                RGBtriples = new byte[3] { 240, 255, 255 };
                return true;
            case "azure1":
                RGBtriples = new byte[3] { 240, 255, 255 };
                return true;
            case "azure2":
                RGBtriples = new byte[3] { 224, 238, 238 };
                return true;
            case "azure3":
                RGBtriples = new byte[3] { 193, 205, 205 };
                return true;
            case "azure4":
                RGBtriples = new byte[3] { 131, 139, 139 };
                return true;
            case "beige":
                RGBtriples = new byte[3] { 245, 245, 220 };
                return true;
            case "bisque":
                RGBtriples = new byte[3] { 255, 228, 196 };
                return true;
            case "bisque1":
                RGBtriples = new byte[3] { 255, 228, 196 };
                return true;
            case "bisque2":
                RGBtriples = new byte[3] { 238, 213, 183 };
                return true;
            case "bisque3":
                RGBtriples = new byte[3] { 205, 183, 158 };
                return true;
            case "bisque4":
                RGBtriples = new byte[3] { 139, 125, 107 };
                return true;
            case "black":
                RGBtriples = new byte[3] { 0, 0, 0 };
                return true;
            case "blanchedalmond":
                RGBtriples = new byte[3] { 255, 235, 205 };
                return true;
            case "blue":
                RGBtriples = new byte[3] { 0, 0, 255 };
                return true;
            case "blue1":
                RGBtriples = new byte[3] { 0, 0, 255 };
                return true;
            case "blue2":
                RGBtriples = new byte[3] { 0, 0, 238 };
                return true;
            case "blue3":
                RGBtriples = new byte[3] { 0, 0, 205 };
                return true;
            case "blue4":
                RGBtriples = new byte[3] { 0, 0, 139 };
                return true;
            case "blueviolet":
                RGBtriples = new byte[3] { 138, 43, 226 };
                return true;
            case "brown":
                RGBtriples = new byte[3] { 165, 42, 42 };
                return true;
            case "brown1":
                RGBtriples = new byte[3] { 255, 64, 64 };
                return true;
            case "brown2":
                RGBtriples = new byte[3] { 238, 59, 59 };
                return true;
            case "brown3":
                RGBtriples = new byte[3] { 205, 51, 51 };
                return true;
            case "brown4":
                RGBtriples = new byte[3] { 139, 35, 35 };
                return true;
            case "burlywood":
                RGBtriples = new byte[3] { 222, 184, 135 };
                return true;
            case "burlywood1":
                RGBtriples = new byte[3] { 255, 211, 155 };
                return true;
            case "burlywood2":
                RGBtriples = new byte[3] { 238, 197, 145 };
                return true;
            case "burlywood3":
                RGBtriples = new byte[3] { 205, 170, 125 };
                return true;
            case "burlywood4":
                RGBtriples = new byte[3] { 139, 115, 85 };
                return true;
            case "cadetblue":
                RGBtriples = new byte[3] { 95, 158, 160 };
                return true;
            case "cadetblue1":
                RGBtriples = new byte[3] { 152, 245, 255 };
                return true;
            case "cadetblue2":
                RGBtriples = new byte[3] { 142, 229, 238 };
                return true;
            case "cadetblue3":
                RGBtriples = new byte[3] { 122, 197, 205 };
                return true;
            case "cadetblue4":
                RGBtriples = new byte[3] { 83, 134, 139 };
                return true;
            case "chartreuse":
                RGBtriples = new byte[3] { 127, 255, 0 };
                return true;
            case "chartreuse1":
                RGBtriples = new byte[3] { 127, 255, 0 };
                return true;
            case "chartreuse2":
                RGBtriples = new byte[3] { 118, 238, 0 };
                return true;
            case "chartreuse3":
                RGBtriples = new byte[3] { 102, 205, 0 };
                return true;
            case "chartreuse4":
                RGBtriples = new byte[3] { 69, 139, 0 };
                return true;
            case "chocolate":
                RGBtriples = new byte[3] { 210, 105, 30 };
                return true;
            case "chocolate1":
                RGBtriples = new byte[3] { 255, 7, 36 };
                return true;
            case "chocolate2":
                RGBtriples = new byte[3] { 238, 8, 33 };
                return true;
            case "chocolate3":
                RGBtriples = new byte[3] { 205, 2, 29 };
                return true;
            case "chocolate4":
                RGBtriples = new byte[3] { 139, 69, 19 };
                return true;
            case "coral":
                RGBtriples = new byte[3] { 255, 127, 80 };
                return true;
            case "coral1":
                RGBtriples = new byte[3] { 255, 114, 86 };
                return true;
            case "coral2":
                RGBtriples = new byte[3] { 238, 106, 80 };
                return true;
            case "coral3":
                RGBtriples = new byte[3] { 205, 91, 69 };
                return true;
            case "coral4":
                RGBtriples = new byte[3] { 139, 62, 47 };
                return true;
            case "cornflowerblue":
                RGBtriples = new byte[3] { 100, 149, 237 };
                return true;
            case "cornsilk":
                RGBtriples = new byte[3] { 255, 248, 220 };
                return true;
            case "cornsilk1":
                RGBtriples = new byte[3] { 255, 248, 220 };
                return true;
            case "cornsilk2":
                RGBtriples = new byte[3] { 238, 232, 205 };
                return true;
            case "cornsilk3":
                RGBtriples = new byte[3] { 205, 200, 177 };
                return true;
            case "cornsilk4":
                RGBtriples = new byte[3] { 139, 136, 120 };
                return true;
            case "cyan":
                RGBtriples = new byte[3] { 0, 255, 255 };
                return true;
            case "cyan1":
                RGBtriples = new byte[3] { 0, 255, 255 };
                return true;
            case "cyan2":
                RGBtriples = new byte[3] { 0, 238, 238 };
                return true;
            case "cyan3":
                RGBtriples = new byte[3] { 0, 205, 205 };
                return true;
            case "cyan4":
                RGBtriples = new byte[3] { 0, 139, 139 };
                return true;
            case "darkblue":
                RGBtriples = new byte[3] { 0, 0, 139 };
                return true;
            case "darkcyan":
                RGBtriples = new byte[3] { 0, 139, 139 };
                return true;
            case "darkgoldenrod":
                RGBtriples = new byte[3] { 184, 134, 11 };
                return true;
            case "darkgoldenrod1":
                RGBtriples = new byte[3] { 255, 185, 15 };
                return true;
            case "darkgoldenrod2":
                RGBtriples = new byte[3] { 238, 173, 14 };
                return true;
            case "darkgoldenrod3":
                RGBtriples = new byte[3] { 205, 149, 12 };
                return true;
            case "darkgoldenrod4":
                RGBtriples = new byte[3] { 139, 101, 8 };
                return true;
            case "darkgreen":
                RGBtriples = new byte[3] { 0, 100, 0 };
                return true;
            case "darkgrey":
                RGBtriples = new byte[3] { 169, 169, 169 };
                return true;
            case "darkkhaki":
                RGBtriples = new byte[3] { 189, 183, 107 };
                return true;
            case "darkmagenta":
                RGBtriples = new byte[3] { 139, 0, 139 };
                return true;
            case "darkolivegreen":
                RGBtriples = new byte[3] { 85, 107, 47 };
                return true;
            case "darkolivegreen1":
                RGBtriples = new byte[3] { 202, 255, 112 };
                return true;
            case "darkolivegreen2":
                RGBtriples = new byte[3] { 188, 238, 104 };
                return true;
            case "darkolivegreen3":
                RGBtriples = new byte[3] { 162, 205, 90 };
                return true;
            case "darkolivegreen4":
                RGBtriples = new byte[3] { 110, 139, 61 };
                return true;
            case "darkorange":
                RGBtriples = new byte[3] { 255, 140, 0 };
                return true;
            case "darkorange1":
                RGBtriples = new byte[3] { 255, 127, 0 };
                return true;
            case "darkorange2":
                RGBtriples = new byte[3] { 238, 118, 0 };
                return true;
            case "darkorange3":
                RGBtriples = new byte[3] { 205, 102, 0 };
                return true;
            case "darkorange4":
                RGBtriples = new byte[3] { 139, 69, 0 };
                return true;
            case "darkorchid":
                RGBtriples = new byte[3] { 153, 50, 204 };
                return true;
            case "darkorchid1":
                RGBtriples = new byte[3] { 191, 62, 255 };
                return true;
            case "darkorchid2":
                RGBtriples = new byte[3] { 178, 58, 238 };
                return true;
            case "darkorchid3":
                RGBtriples = new byte[3] { 154, 50, 205 };
                return true;
            case "darkorchid4":
                RGBtriples = new byte[3] { 104, 34, 139 };
                return true;
            case "darkred":
                RGBtriples = new byte[3] { 139, 0, 0 };
                return true;
            case "darksalmon":
                RGBtriples = new byte[3] { 233, 150, 122 };
                return true;
            case "darkseagreen":
                RGBtriples = new byte[3] { 143, 188, 143 };
                return true;
            case "darkseagreen1":
                RGBtriples = new byte[3] { 193, 255, 193 };
                return true;
            case "darkseagreen2":
                RGBtriples = new byte[3] { 180, 238, 180 };
                return true;
            case "darkseagreen3":
                RGBtriples = new byte[3] { 155, 205, 155 };
                return true;
            case "darkseagreen4":
                RGBtriples = new byte[3] { 105, 139, 105 };
                return true;
            case "darkslateblue":
                RGBtriples = new byte[3] { 72, 61, 139 };
                return true;
            case "darkslategray":
                RGBtriples = new byte[3] { 47, 79, 79 };
                return true;
            case "darkslategray1":
                RGBtriples = new byte[3] { 151, 255, 255 };
                return true;
            case "darkslategray2":
                RGBtriples = new byte[3] { 141, 238, 238 };
                return true;
            case "darkslategray3":
                RGBtriples = new byte[3] { 121, 205, 205 };
                return true;
            case "darkslategray4":
                RGBtriples = new byte[3] { 82, 139, 139 };
                return true;
            case "darkturquoise":
                RGBtriples = new byte[3] { 0, 206, 209 };
                return true;
            case "darkviolet":
                RGBtriples = new byte[3] { 148, 0, 211 };
                return true;
            case "deeppink":
                RGBtriples = new byte[3] { 255, 20, 147 };
                return true;
            case "deeppink1":
                RGBtriples = new byte[3] { 255, 20, 147 };
                return true;
            case "deeppink2":
                RGBtriples = new byte[3] { 238, 18, 137 };
                return true;
            case "deeppink3":
                RGBtriples = new byte[3] { 205, 16, 118 };
                return true;
            case "deeppink4":
                RGBtriples = new byte[3] { 139, 10, 80 };
                return true;
            case "deepskyblue":
                RGBtriples = new byte[3] { 0, 191, 255 };
                return true;
            case "deepskyblue1":
                RGBtriples = new byte[3] { 0, 191, 255 };
                return true;
            case "deepskyblue2":
                RGBtriples = new byte[3] { 0, 178, 238 };
                return true;
            case "deepskyblue3":
                RGBtriples = new byte[3] { 0, 154, 205 };
                return true;
            case "deepskyblue4":
                RGBtriples = new byte[3] { 0, 104, 139 };
                return true;
            case "dimgrey":
                RGBtriples = new byte[3] { 105, 105, 105 };
                return true;
            case "dodgerblue":
                RGBtriples = new byte[3] { 30, 144, 255 };
                return true;
            case "dodgerblue1":
                RGBtriples = new byte[3] { 30, 144, 255 };
                return true;
            case "dodgerblue2":
                RGBtriples = new byte[3] { 28, 134, 238 };
                return true;
            case "dodgerblue3":
                RGBtriples = new byte[3] { 24, 116, 205 };
                return true;
            case "dodgerblue4":
                RGBtriples = new byte[3] { 16, 78, 139 };
                return true;
            case "firebrick":
                RGBtriples = new byte[3] { 178, 34, 34 };
                return true;
            case "firebrick1":
                RGBtriples = new byte[3] { 255, 48, 48 };
                return true;
            case "firebrick2":
                RGBtriples = new byte[3] { 238, 44, 44 };
                return true;
            case "firebrick3":
                RGBtriples = new byte[3] { 205, 38, 38 };
                return true;
            case "firebrick4":
                RGBtriples = new byte[3] { 139, 26, 26 };
                return true;
            case "floralwhite":
                RGBtriples = new byte[3] { 255, 250, 240 };
                return true;
            case "forestgreen":
                RGBtriples = new byte[3] { 34, 139, 34 };
                return true;
            case "gainsboro":
                RGBtriples = new byte[3] { 220, 220, 220 };
                return true;
            case "ghostwhite":
                RGBtriples = new byte[3] { 248, 248, 255 };
                return true;
            case "gold":
                RGBtriples = new byte[3] { 255, 215, 0 };
                return true;
            case "gold1":
                RGBtriples = new byte[3] { 255, 215, 0 };
                return true;
            case "gold2":
                RGBtriples = new byte[3] { 238, 201, 0 };
                return true;
            case "gold3":
                RGBtriples = new byte[3] { 205, 173, 0 };
                return true;
            case "gold4":
                RGBtriples = new byte[3] { 139, 117, 0 };
                return true;
            case "goldenrod":
                RGBtriples = new byte[3] { 218, 165, 32 };
                return true;
            case "goldenrod1":
                RGBtriples = new byte[3] { 255, 193, 37 };
                return true;
            case "goldenrod2":
                RGBtriples = new byte[3] { 238, 180, 34 };
                return true;
            case "goldenrod3":
                RGBtriples = new byte[3] { 205, 155, 29 };
                return true;
            case "goldenrod4":
                RGBtriples = new byte[3] { 139, 105, 20 };
                return true;
            case "gray81":
                RGBtriples = new byte[3] { 207, 207, 207 };
                return true;
            case "gray91":
                RGBtriples = new byte[3] { 232, 232, 232 };
                return true;
            case "green":
                RGBtriples = new byte[3] { 0, 255, 0 };
                return true;
            case "green1":
                RGBtriples = new byte[3] { 0, 255, 0 };
                return true;
            case "green2":
                RGBtriples = new byte[3] { 0, 238, 0 };
                return true;
            case "green3":
                RGBtriples = new byte[3] { 0, 205, 0 };
                return true;
            case "green4":
                RGBtriples = new byte[3] { 0, 139, 0 };
                return true;
            case "greenyellow":
                RGBtriples = new byte[3] { 173, 255, 47 };
                return true;
            case "grey":
                RGBtriples = new byte[3] { 190, 190, 190 };
                return true;
            case "grey11":
                RGBtriples = new byte[3] { 28, 28, 28 };
                return true;
            case "grey21":
                RGBtriples = new byte[3] { 54, 54, 54 };
                return true;
            case "grey31":
                RGBtriples = new byte[3] { 79, 79, 79 };
                return true;
            case "grey41":
                RGBtriples = new byte[3] { 105, 105, 105 };
                return true;
            case "grey51":
                RGBtriples = new byte[3] { 130, 130, 130 };
                return true;
            case "grey61":
                RGBtriples = new byte[3] { 156, 156, 156 };
                return true;
            case "grey71":
                RGBtriples = new byte[3] { 181, 181, 181 };
                return true;
            case "honeydew":
                RGBtriples = new byte[3] { 240, 255, 240 };
                return true;
            case "honeydew1":
                RGBtriples = new byte[3] { 240, 255, 240 };
                return true;
            case "honeydew2":
                RGBtriples = new byte[3] { 224, 238, 224 };
                return true;
            case "honeydew3":
                RGBtriples = new byte[3] { 193, 205, 193 };
                return true;
            case "honeydew4":
                RGBtriples = new byte[3] { 131, 139, 131 };
                return true;
            case "hotpink":
                RGBtriples = new byte[3] { 255, 105, 180 };
                return true;
            case "hotpink1":
                RGBtriples = new byte[3] { 255, 110, 180 };
                return true;
            case "hotpink2":
                RGBtriples = new byte[3] { 238, 106, 167 };
                return true;
            case "hotpink3":
                RGBtriples = new byte[3] { 205, 96, 144 };
                return true;
            case "hotpink4":
                RGBtriples = new byte[3] { 139, 58, 98 };
                return true;
            case "indianred":
                RGBtriples = new byte[3] { 205, 92, 92 };
                return true;
            case "indianred1":
                RGBtriples = new byte[3] { 255, 106, 106 };
                return true;
            case "indianred2":
                RGBtriples = new byte[3] { 238, 99, 99 };
                return true;
            case "indianred3":
                RGBtriples = new byte[3] { 205, 85, 85 };
                return true;
            case "indianred4":
                RGBtriples = new byte[3] { 139, 58, 58 };
                return true;
            case "ivory":
                RGBtriples = new byte[3] { 255, 255, 240 };
                return true;
            case "ivory1":
                RGBtriples = new byte[3] { 255, 255, 240 };
                return true;
            case "ivory2":
                RGBtriples = new byte[3] { 238, 238, 224 };
                return true;
            case "ivory3":
                RGBtriples = new byte[3] { 205, 205, 193 };
                return true;
            case "ivory4":
                RGBtriples = new byte[3] { 139, 139, 131 };
                return true;
            case "khaki1":
                RGBtriples = new byte[3] { 255, 246, 143 };
                return true;
            case "khaki2":
                RGBtriples = new byte[3] { 238, 230, 133 };
                return true;
            case "khaki3":
                RGBtriples = new byte[3] { 205, 198, 115 };
                return true;
            case "khaki4":
                RGBtriples = new byte[3] { 139, 134, 78 };
                return true;
            case "lavender":
                RGBtriples = new byte[3] { 230, 230, 250 };
                return true;
            case "lavenderblush":
                RGBtriples = new byte[3] { 255, 240, 245 };
                return true;
            case "lavenderblush1":
                RGBtriples = new byte[3] { 255, 240, 245 };
                return true;
            case "lavenderblush2":
                RGBtriples = new byte[3] { 238, 224, 229 };
                return true;
            case "lavenderblush3":
                RGBtriples = new byte[3] { 205, 193, 197 };
                return true;
            case "lavenderblush4":
                RGBtriples = new byte[3] { 139, 131, 134 };
                return true;
            case "lawngreen":
                RGBtriples = new byte[3] { 124, 252, 0 };
                return true;
            case "lemonchiffon":
                RGBtriples = new byte[3] { 255, 250, 205 };
                return true;
            case "lemonchiffon1":
                RGBtriples = new byte[3] { 255, 250, 205 };
                return true;
            case "lemonchiffon2":
                RGBtriples = new byte[3] { 238, 233, 191 };
                return true;
            case "lemonchiffon3":
                RGBtriples = new byte[3] { 205, 201, 165 };
                return true;
            case "lemonchiffon4":
                RGBtriples = new byte[3] { 139, 137, 112 };
                return true;
            case "lightblue":
                RGBtriples = new byte[3] { 173, 216, 230 };
                return true;
            case "lightblue1":
                RGBtriples = new byte[3] { 191, 239, 255 };
                return true;
            case "lightblue2":
                RGBtriples = new byte[3] { 178, 223, 238 };
                return true;
            case "lightblue3":
                RGBtriples = new byte[3] { 154, 192, 205 };
                return true;
            case "lightblue4":
                RGBtriples = new byte[3] { 104, 131, 139 };
                return true;
            case "lightcoral":
                RGBtriples = new byte[3] { 240, 128, 128 };
                return true;
            case "lightcyan":
                RGBtriples = new byte[3] { 224, 255, 255 };
                return true;
            case "lightcyan1":
                RGBtriples = new byte[3] { 224, 255, 255 };
                return true;
            case "lightcyan2":
                RGBtriples = new byte[3] { 209, 238, 238 };
                return true;
            case "lightcyan3":
                RGBtriples = new byte[3] { 180, 205, 205 };
                return true;
            case "lightcyan4":
                RGBtriples = new byte[3] { 122, 139, 139 };
                return true;
            case "lightgoldenrod":
                RGBtriples = new byte[3] { 238, 221, 130 };
                return true;
            case "lightgoldenrod1":
                RGBtriples = new byte[3] { 255, 236, 139 };
                return true;
            case "lightgoldenrod2":
                RGBtriples = new byte[3] { 238, 220, 130 };
                return true;
            case "lightgoldenrod3":
                RGBtriples = new byte[3] { 205, 190, 112 };
                return true;
            case "lightgoldenrod4":
                RGBtriples = new byte[3] { 139, 129, 76 };
                return true;
            case "lightgray":
                RGBtriples = new byte[3] { 211, 211, 211 };
                return true;
            case "lightgreen":
                RGBtriples = new byte[3] { 144, 238, 144 };
                return true;
            case "lightpink":
                RGBtriples = new byte[3] { 255, 182, 193 };
                return true;
            case "lightpink1":
                RGBtriples = new byte[3] { 255, 174, 185 };
                return true;
            case "lightpink2":
                RGBtriples = new byte[3] { 238, 162, 173 };
                return true;
            case "lightpink3":
                RGBtriples = new byte[3] { 205, 140, 149 };
                return true;
            case "lightpink4":
                RGBtriples = new byte[3] { 139, 95, 101 };
                return true;
            case "lightsalmon":
                RGBtriples = new byte[3] { 255, 160, 122 };
                return true;
            case "lightsalmon1":
                RGBtriples = new byte[3] { 255, 160, 122 };
                return true;
            case "lightsalmon2":
                RGBtriples = new byte[3] { 238, 149, 114 };
                return true;
            case "lightsalmon3":
                RGBtriples = new byte[3] { 205, 129, 98 };
                return true;
            case "lightsalmon4":
                RGBtriples = new byte[3] { 139, 87, 66 };
                return true;
            case "lightseagreen":
                RGBtriples = new byte[3] { 32, 178, 170 };
                return true;
            case "lightskyblue":
                RGBtriples = new byte[3] { 135, 206, 250 };
                return true;
            case "lightskyblue1":
                RGBtriples = new byte[3] { 176, 226, 255 };
                return true;
            case "lightskyblue2":
                RGBtriples = new byte[3] { 164, 211, 238 };
                return true;
            case "lightskyblue3":
                RGBtriples = new byte[3] { 141, 182, 205 };
                return true;
            case "lightskyblue4":
                RGBtriples = new byte[3] { 96, 123, 139 };
                return true;
            case "lightslateblue":
                RGBtriples = new byte[3] { 132, 112, 255 };
                return true;
            case "lightslategray":
                RGBtriples = new byte[3] { 119, 136, 153 };
                return true;
            case "lightsteelblue":
                RGBtriples = new byte[3] { 176, 196, 222 };
                return true;
            case "lightsteelblue1":
                RGBtriples = new byte[3] { 202, 225, 255 };
                return true;
            case "lightsteelblue2":
                RGBtriples = new byte[3] { 188, 210, 238 };
                return true;
            case "lightsteelblue3":
                RGBtriples = new byte[3] { 162, 181, 205 };
                return true;
            case "lightsteelblue4":
                RGBtriples = new byte[3] { 110, 123, 139 };
                return true;
            case "lightyellow":
                RGBtriples = new byte[3] { 255, 255, 224 };
                return true;
            case "lightyellow1":
                RGBtriples = new byte[3] { 255, 255, 224 };
                return true;
            case "lightyellow2":
                RGBtriples = new byte[3] { 238, 238, 209 };
                return true;
            case "lightyellow3":
                RGBtriples = new byte[3] { 205, 205, 180 };
                return true;
            case "lightyellow4":
                RGBtriples = new byte[3] { 139, 139, 122 };
                return true;
            case "limegreen":
                RGBtriples = new byte[3] { 50, 205, 50 };
                return true;
            case "linen":
                RGBtriples = new byte[3] { 250, 240, 230 };
                return true;
            case "ltgoldenrodyello":
                RGBtriples = new byte[3] { 250, 250, 210 };
                return true;
            case "magenta":
                RGBtriples = new byte[3] { 255, 0, 255 };
                return true;
            case "magenta1":
                RGBtriples = new byte[3] { 255, 0, 255 };
                return true;
            case "magenta2":
                RGBtriples = new byte[3] { 238, 0, 238 };
                return true;
            case "magenta3":
                RGBtriples = new byte[3] { 205, 0, 205 };
                return true;
            case "magenta4":
                RGBtriples = new byte[3] { 139, 0, 139 };
                return true;
            case "maroon":
                RGBtriples = new byte[3] { 176, 48, 96 };
                return true;
            case "maroon1":
                RGBtriples = new byte[3] { 255, 52, 179 };
                return true;
            case "maroon2":
                RGBtriples = new byte[3] { 238, 48, 167 };
                return true;
            case "maroon3":
                RGBtriples = new byte[3] { 205, 41, 144 };
                return true;
            case "maroon4":
                RGBtriples = new byte[3] { 139, 28, 98 };
                return true;
            case "mediumaquamarine":
                RGBtriples = new byte[3] { 102, 205, 170 };
                return true;
            case "mediumblue":
                RGBtriples = new byte[3] { 0, 0, 205 };
                return true;
            case "mediumorchid":
                RGBtriples = new byte[3] { 186, 85, 211 };
                return true;
            case "mediumorchid1":
                RGBtriples = new byte[3] { 224, 102, 255 };
                return true;
            case "mediumorchid2":
                RGBtriples = new byte[3] { 209, 95, 238 };
                return true;
            case "mediumorchid3":
                RGBtriples = new byte[3] { 180, 82, 205 };
                return true;
            case "mediumorchid4":
                RGBtriples = new byte[3] { 122, 55, 139 };
                return true;
            case "mediumpurple":
                RGBtriples = new byte[3] { 147, 112, 219 };
                return true;
            case "mediumpurple1":
                RGBtriples = new byte[3] { 171, 130, 255 };
                return true;
            case "mediumpurple2":
                RGBtriples = new byte[3] { 159, 121, 238 };
                return true;
            case "mediumpurple3":
                RGBtriples = new byte[3] { 137, 104, 205 };
                return true;
            case "mediumpurple4":
                RGBtriples = new byte[3] { 93, 71, 139 };
                return true;
            case "mediumseagreen":
                RGBtriples = new byte[3] { 60, 179, 113 };
                return true;
            case "mediumslateblue":
                RGBtriples = new byte[3] { 123, 104, 238 };
                return true;
            case "mediumturquoise":
                RGBtriples = new byte[3] { 72, 209, 204 };
                return true;
            case "mediumvioletred":
                RGBtriples = new byte[3] { 199, 21, 133 };
                return true;
            case "medspringgreen":
                RGBtriples = new byte[3] { 0, 250, 154 };
                return true;
            case "midnightblue":
                RGBtriples = new byte[3] { 25, 25, 112 };
                return true;
            case "mintcream":
                RGBtriples = new byte[3] { 245, 255, 250 };
                return true;
            case "mistyrose":
                RGBtriples = new byte[3] { 255, 228, 225 };
                return true;
            case "mistyrose1":
                RGBtriples = new byte[3] { 255, 228, 225 };
                return true;
            case "mistyrose2":
                RGBtriples = new byte[3] { 238, 213, 210 };
                return true;
            case "mistyrose3":
                RGBtriples = new byte[3] { 205, 183, 181 };
                return true;
            case "mistyrose4":
                RGBtriples = new byte[3] { 139, 125, 123 };
                return true;
            case "moccasin":
                RGBtriples = new byte[3] { 255, 228, 181 };
                return true;
            case "navajowhite":
                RGBtriples = new byte[3] { 255, 222, 173 };
                return true;
            case "navajowhite1":
                RGBtriples = new byte[3] { 255, 222, 73 };
                return true;
            case "navajowhite2":
                RGBtriples = new byte[3] { 238, 207, 161 };
                return true;
            case "navajowhite3":
                RGBtriples = new byte[3] { 205, 179, 139 };
                return true;
            case "navajowhite4":
                RGBtriples = new byte[3] { 139, 121, 94 };
                return true;
            case "navyblue":
                RGBtriples = new byte[3] { 0, 0, 128 };
                return true;
            case "oldlace":
                RGBtriples = new byte[3] { 253, 245, 230 };
                return true;
            case "olivedrab":
                RGBtriples = new byte[3] { 107, 142, 35 };
                return true;
            case "olivedrab1":
                RGBtriples = new byte[3] { 192, 255, 62 };
                return true;
            case "olivedrab2":
                RGBtriples = new byte[3] { 179, 238, 58 };
                return true;
            case "olivedrab3":
                RGBtriples = new byte[3] { 154, 205, 50 };
                return true;
            case "olivedrab4":
                RGBtriples = new byte[3] { 105, 139, 34 };
                return true;
            case "orange":
                RGBtriples = new byte[3] { 255, 165, 0 };
                return true;
            case "orange1":
                RGBtriples = new byte[3] { 255, 165, 0 };
                return true;
            case "orange2":
                RGBtriples = new byte[3] { 238, 154, 0 };
                return true;
            case "orange3":
                RGBtriples = new byte[3] { 205, 133, 0 };
                return true;
            case "orange4":
                RGBtriples = new byte[3] { 139, 90, 0 };
                return true;
            case "orangered":
                RGBtriples = new byte[3] { 255, 69, 0 };
                return true;
            case "orangered1":
                RGBtriples = new byte[3] { 255, 69, 0 };
                return true;
            case "orangered2":
                RGBtriples = new byte[3] { 238, 64, 0 };
                return true;
            case "orangered3":
                RGBtriples = new byte[3] { 205, 55, 0 };
                return true;
            case "orangered4":
                RGBtriples = new byte[3] { 139, 37, 0 };
                return true;
            case "orchid":
                RGBtriples = new byte[3] { 218, 112, 214 };
                return true;
            case "orchid1":
                RGBtriples = new byte[3] { 255, 131, 250 };
                return true;
            case "orchid2":
                RGBtriples = new byte[3] { 238, 122, 233 };
                return true;
            case "orchid3":
                RGBtriples = new byte[3] { 205, 105, 201 };
                return true;
            case "orchid4":
                RGBtriples = new byte[3] { 139, 71, 137 };
                return true;
            case "palegoldenrod":
                RGBtriples = new byte[3] { 238, 232, 170 };
                return true;
            case "palegreen":
                RGBtriples = new byte[3] { 152, 251, 152 };
                return true;
            case "palegreen1":
                RGBtriples = new byte[3] { 154, 255, 154 };
                return true;
            case "palegreen2":
                RGBtriples = new byte[3] { 144, 238, 144 };
                return true;
            case "palegreen3":
                RGBtriples = new byte[3] { 124, 205, 124 };
                return true;
            case "palegreen4":
                RGBtriples = new byte[3] { 84, 139, 84 };
                return true;
            case "paleturquoise":
                RGBtriples = new byte[3] { 175, 238, 238 };
                return true;
            case "paleturquoise1":
                RGBtriples = new byte[3] { 187, 255, 255 };
                return true;
            case "paleturquoise2":
                RGBtriples = new byte[3] { 174, 238, 238 };
                return true;
            case "paleturquoise3":
                RGBtriples = new byte[3] { 150, 205, 205 };
                return true;
            case "paleturquoise4":
                RGBtriples = new byte[3] { 102, 139, 139 };
                return true;
            case "palevioletred":
                RGBtriples = new byte[3] { 219, 112, 147 };
                return true;
            case "palevioletred1":
                RGBtriples = new byte[3] { 255, 130, 171 };
                return true;
            case "palevioletred2":
                RGBtriples = new byte[3] { 238, 121, 159 };
                return true;
            case "palevioletred3":
                RGBtriples = new byte[3] { 205, 104, 137 };
                return true;
            case "palevioletred4":
                RGBtriples = new byte[3] { 139, 71, 93 };
                return true;
            case "papayawhip":
                RGBtriples = new byte[3] { 255, 239, 213 };
                return true;
            case "peachpuff":
                RGBtriples = new byte[3] { 255, 218, 185 };
                return true;
            case "peachpuff1":
                RGBtriples = new byte[3] { 255, 218, 185 };
                return true;
            case "peachpuff2":
                RGBtriples = new byte[3] { 238, 203, 173 };
                return true;
            case "peachpuff3":
                RGBtriples = new byte[3] { 205, 175, 149 };
                return true;
            case "peachpuff4":
                RGBtriples = new byte[3] { 139, 119, 101 };
                return true;
            case "peru":
                RGBtriples = new byte[3] { 205, 133, 63 };
                return true;
            case "pink":
                RGBtriples = new byte[3] { 255, 192, 203 };
                return true;
            case "pink1":
                RGBtriples = new byte[3] { 255, 181, 197 };
                return true;
            case "pink2":
                RGBtriples = new byte[3] { 238, 169, 184 };
                return true;
            case "pink3":
                RGBtriples = new byte[3] { 205, 145, 158 };
                return true;
            case "pink4":
                RGBtriples = new byte[3] { 139, 99, 108 };
                return true;
            case "plum":
                RGBtriples = new byte[3] { 221, 160, 221 };
                return true;
            case "plum1":
                RGBtriples = new byte[3] { 255, 187, 255 };
                return true;
            case "plum2":
                RGBtriples = new byte[3] { 238, 174, 238 };
                return true;
            case "plum3":
                RGBtriples = new byte[3] { 205, 150, 205 };
                return true;
            case "plum4":
                RGBtriples = new byte[3] { 139, 102, 139 };
                return true;
            case "powderblue":
                RGBtriples = new byte[3] { 176, 224, 230 };
                return true;
            case "purple":
                RGBtriples = new byte[3] { 160, 32, 240 };
                return true;
            case "purple1":
                RGBtriples = new byte[3] { 155, 48, 255 };
                return true;
            case "purple2":
                RGBtriples = new byte[3] { 145, 44, 238 };
                return true;
            case "purple3":
                RGBtriples = new byte[3] { 125, 38, 205 };
                return true;
            case "purple4":
                RGBtriples = new byte[3] { 85, 26, 139 };
                return true;
            case "red":
                RGBtriples = new byte[3] { 255, 0, 0 };
                return true;
            case "red1":
                RGBtriples = new byte[3] { 255, 0, 0 };
                return true;
            case "red2":
                RGBtriples = new byte[3] { 238, 0, 0 };
                return true;
            case "red3":
                RGBtriples = new byte[3] { 205, 0, 0 };
                return true;
            case "red4":
                RGBtriples = new byte[3] { 139, 0, 0 };
                return true;
            case "rosybrown":
                RGBtriples = new byte[3] { 188, 143, 143 };
                return true;
            case "rosybrown1":
                RGBtriples = new byte[3] { 255, 193, 193 };
                return true;
            case "rosybrown2":
                RGBtriples = new byte[3] { 238, 180, 180 };
                return true;
            case "rosybrown3":
                RGBtriples = new byte[3] { 205, 155, 155 };
                return true;
            case "rosybrown4":
                RGBtriples = new byte[3] { 139, 105, 105 };
                return true;
            case "royalblue":
                RGBtriples = new byte[3] { 65, 105, 225 };
                return true;
            case "royalblue1":
                RGBtriples = new byte[3] { 72, 118, 255 };
                return true;
            case "royalblue2":
                RGBtriples = new byte[3] { 67, 110, 238 };
                return true;
            case "royalblue3":
                RGBtriples = new byte[3] { 58, 95, 205 };
                return true;
            case "royalblue4":
                RGBtriples = new byte[3] { 39, 64, 139 };
                return true;
            case "saddlebrown":
                RGBtriples = new byte[3] { 139, 69, 19 };
                return true;
            case "salmon":
                RGBtriples = new byte[3] { 250, 128, 114 };
                return true;
            case "salmon1":
                RGBtriples = new byte[3] { 255, 140, 105 };
                return true;
            case "salmon2":
                RGBtriples = new byte[3] { 238, 130, 98 };
                return true;
            case "salmon3":
                RGBtriples = new byte[3] { 205, 112, 84 };
                return true;
            case "salmon4":
                RGBtriples = new byte[3] { 139, 76, 57 };
                return true;
            case "sandybrown":
                RGBtriples = new byte[3] { 244, 164, 96 };
                return true;
            case "seagreen":
                RGBtriples = new byte[3] { 46, 139, 87 };
                return true;
            case "seagreen1":
                RGBtriples = new byte[3] { 84, 255, 159 };
                return true;
            case "seagreen2":
                RGBtriples = new byte[3] { 78, 238, 148 };
                return true;
            case "seagreen3":
                RGBtriples = new byte[3] { 67, 205, 128 };
                return true;
            case "seagreen4":
                RGBtriples = new byte[3] { 46, 139, 87 };
                return true;
            case "seashell":
                RGBtriples = new byte[3] { 255, 245, 238 };
                return true;
            case "seashell1":
                RGBtriples = new byte[3] { 255, 245, 238 };
                return true;
            case "seashell2":
                RGBtriples = new byte[3] { 238, 229, 222 };
                return true;
            case "seashell3":
                RGBtriples = new byte[3] { 205, 197, 191 };
                return true;
            case "seashell4":
                RGBtriples = new byte[3] { 139, 134, 130 };
                return true;
            case "sienna":
                RGBtriples = new byte[3] { 160, 82, 45 };
                return true;
            case "sienna1":
                RGBtriples = new byte[3] { 255, 130, 71 };
                return true;
            case "sienna2":
                RGBtriples = new byte[3] { 238, 121, 66 };
                return true;
            case "sienna3":
                RGBtriples = new byte[3] { 205, 104, 57 };
                return true;
            case "sienna4":
                RGBtriples = new byte[3] { 139, 71, 38 };
                return true;
            case "skyblue":
                RGBtriples = new byte[3] { 135, 206, 235 };
                return true;
            case "skyblue1":
                RGBtriples = new byte[3] { 135, 206, 255 };
                return true;
            case "skyblue2":
                RGBtriples = new byte[3] { 126, 192, 238 };
                return true;
            case "skyblue3":
                RGBtriples = new byte[3] { 108, 166, 205 };
                return true;
            case "skyblue4":
                RGBtriples = new byte[3] { 74, 112, 139 };
                return true;
            case "slateblue":
                RGBtriples = new byte[3] { 106, 90, 205 };
                return true;
            case "slateblue1":
                RGBtriples = new byte[3] { 131, 111, 255 };
                return true;
            case "slateblue2":
                RGBtriples = new byte[3] { 122, 103, 238 };
                return true;
            case "slateblue3":
                RGBtriples = new byte[3] { 105, 89, 205 };
                return true;
            case "slateblue4":
                RGBtriples = new byte[3] { 105, 89, 205 };
                return true;
            case "slategray1":
                RGBtriples = new byte[3] { 198, 226, 255 };
                return true;
            case "slategray2":
                RGBtriples = new byte[3] { 185, 211, 238 };
                return true;
            case "slategray3":
                RGBtriples = new byte[3] { 159, 182, 205 };
                return true;
            case "slategray4":
                RGBtriples = new byte[3] { 108, 123, 139 };
                return true;
            case "slategrey":
                RGBtriples = new byte[3] { 112, 128, 144 };
                return true;
            case "snow":
                RGBtriples = new byte[3] { 255, 250, 250 };
                return true;
            case "snow1":
                RGBtriples = new byte[3] { 255, 250, 250 };
                return true;
            case "snow2":
                RGBtriples = new byte[3] { 238, 233, 233 };
                return true;
            case "snow3":
                RGBtriples = new byte[3] { 205, 201, 201 };
                return true;
            case "snow4":
                RGBtriples = new byte[3] { 139, 137, 137 };
                return true;
            case "springgreen":
                RGBtriples = new byte[3] { 0, 255, 127 };
                return true;
            case "springgreen1":
                RGBtriples = new byte[3] { 0, 255, 127 };
                return true;
            case "springgreen2":
                RGBtriples = new byte[3] { 0, 238, 118 };
                return true;
            case "springgreen3":
                RGBtriples = new byte[3] { 0, 205, 102 };
                return true;
            case "springgreen4":
                RGBtriples = new byte[3] { 0, 139, 69 };
                return true;
            case "steelblue":
                RGBtriples = new byte[3] { 70, 130, 180 };
                return true;
            case "steelblue1":
                RGBtriples = new byte[3] { 99, 184, 255 };
                return true;
            case "steelblue2":
                RGBtriples = new byte[3] { 92, 172, 238 };
                return true;
            case "steelblue3":
                RGBtriples = new byte[3] { 79, 148, 205 };
                return true;
            case "steelblue4":
                RGBtriples = new byte[3] { 54, 100, 139 };
                return true;
            case "tan":
                RGBtriples = new byte[3] { 210, 180, 140 };
                return true;
            case "tan1":
                RGBtriples = new byte[3] { 255, 165, 79 };
                return true;
            case "tan2":
                RGBtriples = new byte[3] { 238, 154, 73 };
                return true;
            case "tan3":
                RGBtriples = new byte[3] { 205, 133, 63 };
                return true;
            case "tan4":
                RGBtriples = new byte[3] { 139, 90, 43 };
                return true;
            case "thistle":
                RGBtriples = new byte[3] { 216, 191, 216 };
                return true;
            case "thistle1":
                RGBtriples = new byte[3] { 255, 225, 255 };
                return true;
            case "thistle2":
                RGBtriples = new byte[3] { 238, 210, 238 };
                return true;
            case "thistle3":
                RGBtriples = new byte[3] { 205, 181, 205 };
                return true;
            case "thistle4":
                RGBtriples = new byte[3] { 139, 123, 139 };
                return true;
            case "tomato":
                RGBtriples = new byte[3] { 255, 99, 71 };
                return true;
            case "tomato1":
                RGBtriples = new byte[3] { 255, 99, 71 };
                return true;
            case "tomato2":
                RGBtriples = new byte[3] { 238, 92, 66 };
                return true;
            case "tomato3":
                RGBtriples = new byte[3] { 205, 79, 57 };
                return true;
            case "tomato4":
                RGBtriples = new byte[3] { 139, 54, 38 };
                return true;
            case "turquoise":
                RGBtriples = new byte[3] { 64, 224, 208 };
                return true;
            case "turquoise1":
                RGBtriples = new byte[3] { 0, 245, 255 };
                return true;
            case "turquoise2":
                RGBtriples = new byte[3] { 0, 229, 238 };
                return true;
            case "turquoise3":
                RGBtriples = new byte[3] { 0, 197, 205 };
                return true;
            case "turquoise4":
                RGBtriples = new byte[3] { 0, 134, 139 };
                return true;
            case "violet":
                RGBtriples = new byte[3] { 238, 130, 238 };
                return true;
            case "violetred":
                RGBtriples = new byte[3] { 208, 32, 144 };
                return true;
            case "violetred1":
                RGBtriples = new byte[3] { 255, 62, 150 };
                return true;
            case "violetred2":
                RGBtriples = new byte[3] { 238, 58, 140 };
                return true;
            case "violetred3":
                RGBtriples = new byte[3] { 205, 50, 120 };
                return true;
            case "violetred4":
                RGBtriples = new byte[3] { 139, 34, 82 };
                return true;
            case "wheat":
                RGBtriples = new byte[3] { 245, 222, 179 };
                return true;
            case "wheat1":
                RGBtriples = new byte[3] { 255, 231, 186 };
                return true;
            case "wheat2":
                RGBtriples = new byte[3] { 238, 216, 174 };
                return true;
            case "wheat3":
                RGBtriples = new byte[3] { 205, 186, 150 };
                return true;
            case "wheat4":
                RGBtriples = new byte[3] { 139, 126, 102 };
                return true;
            case "white":
                RGBtriples = new byte[3] { 255, 255, 255 };
                return true;
            case "whitesmoke":
                RGBtriples = new byte[3] { 245, 245, 245 };
                return true;
            case "yellow":
                RGBtriples = new byte[3] { 255, 255, 0 };
                return true;
            case "yellow1":
                RGBtriples = new byte[3] { 255, 255, 0 };
                return true;
            case "yellow2":
                RGBtriples = new byte[3] { 238, 238, 0 };
                return true;
            case "yellow3":
                RGBtriples = new byte[3] { 205, 205, 0 };
                return true;
            case "yellow4":
                RGBtriples = new byte[3] { 139, 139, 0 };
                return true;
            case "yellowgreen":
                RGBtriples = new byte[3] { 154, 205, 50 };
                return true;
        }
        return false;
    }
}