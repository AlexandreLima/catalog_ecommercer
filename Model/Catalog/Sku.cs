﻿using System.Collections.Generic;
using MongoDB.Bson;

namespace EcommercerCatalog.Model.Catalog
{
    public class Sku
    {
        public Sku()
        {
            Id = ObjectId.GenerateNewId();
        }
        
        public ObjectId Id { get; private set; }
        public int itemId { get; set; }
        public int parentItemId { get; set; }
        public string name { get; set; }
        public double msrp { get; set; }
        public double salePrice { get; set; }
        public string upc { get; set; }
        public string categoryPath { get; set; }
        public string shortDescription { get; set; }
        public string longDescription { get; set; }
        public string thumbnailImage { get; set; }
        public string mediumImage { get; set; }
        public string largeImage { get; set; }
        public string productTrackingUrl { get; set; }
        public double standardShipRate { get; set; }
        public bool marketplace { get; set; }
        public string modelNumber { get; set; }
        public string productUrl { get; set; }
        public string customerRating { get; set; }
        public int numReviews { get; set; }
        public string customerRatingImage { get; set; }
        public string categoryNode { get; set; }
        public bool bundle { get; set; }
        public string stock { get; set; }
        public string addToCartUrl { get; set; }
        public string affiliateAddToCartUrl { get; set; }
        public List<Image> imageEntities { get; set; }
        public string offerType { get; set; }
        public bool isTwoDayShippingEligible { get; set; }
        public bool availableOnline { get; set; }
        public GiftOptions giftOptions { get; set; }

        public string FindCategory { get; set; }
    }

}