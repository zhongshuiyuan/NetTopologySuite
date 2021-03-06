﻿using System;
using System.Collections.Generic;
using System.IO;
using GeoAPI.Geometries;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;

namespace NetTopologySuite.Tests.NUnit
{
    public class GeometryUtils
    {
        //TODO: allow specifying GeometryFactory
        public static WKTReader reader = new WKTReader();

        public static IList<IGeometry> ReadWKT(string[] inputWKT)
        {
            var geometries = new List<IGeometry>();
            foreach (string geomWkt in inputWKT)
            {
                geometries.Add(reader.Read(geomWkt));
            }
            return geometries;
        }

        public static IGeometry ReadWKT(string inputWKT)
        {
            return reader.Read(inputWKT);
        }

        public static IList<IGeometry> ReadWKTFile(Stream stream)
        {
            var fileRdr = new WKTFileReader(new StreamReader(stream), new WKTReader());
            var geoms = fileRdr.Read();
            return geoms;
        }

        public static bool IsEqual(IGeometry a, IGeometry b)
        {
            var a2 = Normalize(a);
            var b2 = Normalize(b);
            return a2.EqualsExact(b2);
        }

        public static IGeometry Normalize(IGeometry g)
        {
            var g2 = (Geometry) g.Copy();
            g2.Normalize();
            return g2;
        }
    }
}
