﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MagniPiBusinessEntities.Common;

namespace MagniPi.Common
{
    public class MessageStore
    {
        public static FixedSizeGenericHashTable<string, FriendlyMessage> hash = new FixedSizeGenericHashTable<string, FriendlyMessage>(400);

        static MessageStore()
        {
            #region System

            FriendlyMessage SYS01 = new FriendlyMessage("SYS01", MessageType.Error, "We are currently unable to process your request, Please try again later or contact system administrator.");
            hash.Add("SYS01", SYS01);

            FriendlyMessage SYS02 = new FriendlyMessage("SYS02", MessageType.Information, "Your session has expired. Please login again.");
            hash.Add("SYS02", SYS02);

            FriendlyMessage SYS03 = new FriendlyMessage("SYS03", MessageType.Error, "Please login with valid Username & Password to view this page.");
            hash.Add("SYS03", SYS03);

            FriendlyMessage SYS04 = new FriendlyMessage("SYS04", MessageType.Information, "No records found.");
            hash.Add("SYS04", SYS04);

            FriendlyMessage SYS05 = new FriendlyMessage("SYS05", MessageType.Information, "Password has been changed successfully.");
            hash.Add("SYS05", SYS05);

            FriendlyMessage SYS06 = new FriendlyMessage("SYS06", MessageType.Error, "You dont have online access. Please contact administrator.");
            hash.Add("SYS06", SYS06);

            FriendlyMessage SYS07 = new FriendlyMessage("SYS07", MessageType.Error, "File not found, Please contact administrator.");
            hash.Add("SYS07", SYS07);

            FriendlyMessage SYS08 = new FriendlyMessage("SYS08", MessageType.Error, "Entered User is not an Valid Active directory Member");
            hash.Add("SYS08", SYS08);

            #endregion

            #region Attachment

            FriendlyMessage ATS01 = new FriendlyMessage("ATS01", MessageType.Success, "Files uploaded successfully.");
            hash.Add("ATS01", ATS01);

            FriendlyMessage ATS02 = new FriendlyMessage("ATS02", MessageType.Success, "Files deleted successfully.");
            hash.Add("ATS02", ATS02);

            #endregion

            #region Blog

            FriendlyMessage BLG01 = new FriendlyMessage("BLG01", MessageType.Success, "Blog added successfully.");
            hash.Add("BLG01", BLG01);

            FriendlyMessage BLG02 = new FriendlyMessage("BLG02", MessageType.Success, "Blog updated successfully.");
            hash.Add("BLG02", BLG02);

            #endregion

            #region Service

            FriendlyMessage SRV01 = new FriendlyMessage("SRV01", MessageType.Success, "Service added successfully.");
            hash.Add("SRV01", SRV01);

            FriendlyMessage SRV02 = new FriendlyMessage("SRV02", MessageType.Success, "Service updated successfully.");
            hash.Add("SRV02", SRV02);

            #endregion

            #region Testimonial

            FriendlyMessage TST01 = new FriendlyMessage("TST01", MessageType.Success, "Testimonial added successfully.");
            hash.Add("TST01", TST01);

            FriendlyMessage TST02 = new FriendlyMessage("TST02", MessageType.Success, "Testimonial updated successfully.");
            hash.Add("TST02", TST02);

            #endregion

            #region About Us

            FriendlyMessage ABT01 = new FriendlyMessage("ABT01", MessageType.Success, "About us updated successfully.");
            hash.Add("ABT01", ABT01);

            #endregion

            #region Customer

            FriendlyMessage CST01 = new FriendlyMessage("CST01", MessageType.Success, "Customer added successfully.");
            hash.Add("CST01", CST01);

            FriendlyMessage CST02 = new FriendlyMessage("CST02", MessageType.Success, "Customer updated successfully.");
            hash.Add("CST02", CST02);

            FriendlyMessage CMEM01 = new FriendlyMessage("CMEM01", MessageType.Success, "Member added successfully.");
            hash.Add("CMEM01", CMEM01);

            FriendlyMessage CMEM02 = new FriendlyMessage("CMEM02", MessageType.Success, "Member updated successfully.");
            hash.Add("CMEM02", CMEM02);

            #endregion

            #region Event

            FriendlyMessage EVT01 = new FriendlyMessage("EVT01", MessageType.Success, "Event added successfully.");
            hash.Add("EVT01", EVT01);

            FriendlyMessage EVT02 = new FriendlyMessage("EVT02", MessageType.Success, "Event updated successfully.");
            hash.Add("EVT02", EVT02);

            FriendlyMessage EVT03 = new FriendlyMessage("EVT03", MessageType.Success, "Event date added successfully.");
            hash.Add("EVT03", EVT03);

            FriendlyMessage EVT04 = new FriendlyMessage("EVT04", MessageType.Success, "Event date updated successfully.");
            hash.Add("EVT04", EVT04);

            FriendlyMessage EVT05 = new FriendlyMessage("EVT05", MessageType.Success, "Saved successfully.");
            hash.Add("EVT05", EVT05);

            FriendlyMessage EVT06 = new FriendlyMessage("EVT06", MessageType.Success, "Member saved successfully.");
            hash.Add("EVT06", EVT06);

            FriendlyMessage EVT07 = new FriendlyMessage("EVT07", MessageType.Success, "Event attendance saved successfully.");
            hash.Add("EVT07", EVT07);

            FriendlyMessage EVT08 = new FriendlyMessage("EVT08", MessageType.Success, "Customer removed successfully.");
            hash.Add("EVT08", EVT08);

            #endregion


        }

        public static FriendlyMessage Get(string code)
        {
            FriendlyMessage message = hash.Find(code);

            return message;
        }

        /// <summary>
        /// struct to hold generic key and value
        /// </summary>
        /// <typeparam name="K">Key</typeparam>
        /// <typeparam name="V">Value</typeparam>
        /// <remarks></remarks>
        public struct KeyValue<K, V>
        {
            /// <summary>
            /// Gets or sets the key.
            /// </summary>
            /// <value>The key.</value>
            /// <remarks></remarks>
            public K Key { get; set; }
            /// <summary>
            /// Gets or sets the value.
            /// </summary>
            /// <value>The value.</value>
            /// <remarks></remarks>
            public V Value { get; set; }
        }

        /// <summary>
        /// FixedSizeGenericHashTable
        /// </summary>
        /// <typeparam name="K">Key</typeparam>
        /// <typeparam name="V">Value</typeparam>
        /// <remarks>Object for FixedSizeGenericHashTable of key K and of value V</remarks>
        public class FixedSizeGenericHashTable<K, V>
        {
            private readonly int size;
            private readonly LinkedList<KeyValue<K, V>>[] items;

            public FixedSizeGenericHashTable(int size)
            {
                this.size = size;
                items = new LinkedList<KeyValue<K, V>>[size];
            }

            protected int GetArrayPosition(K key)
            {
                int position = key.GetHashCode() % size;
                return Math.Abs(position);
            }

            public V Find(K key)
            {
                int position = GetArrayPosition(key);
                LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
                foreach (KeyValue<K, V> item in linkedList)
                {
                    if (item.Key.Equals(key))
                    {
                        return item.Value;
                    }
                }

                return default(V);
            }

            /// <summary>
            /// Adds the specified key.
            /// </summary>
            /// <param name="key">The key.</param>
            /// <param name="value">The value.</param>
            /// <remarks></remarks>
            public void Add(K key, V value)
            {
                int position = GetArrayPosition(key);
                LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
                KeyValue<K, V> item = new KeyValue<K, V>() { Key = key, Value = value };
                linkedList.AddLast(item);
            }

            /// <summary>
            /// Removes the specified key.
            /// </summary>
            /// <param name="key">The key.</param>
            /// <remarks></remarks>
            public void Remove(K key)
            {
                int position = GetArrayPosition(key);
                LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
                bool itemFound = false;
                KeyValue<K, V> foundItem = default(KeyValue<K, V>);
                foreach (KeyValue<K, V> item in linkedList)
                {
                    if (item.Key.Equals(key))
                    {
                        itemFound = true;
                        foundItem = item;
                    }
                }

                if (itemFound)
                {
                    linkedList.Remove(foundItem);
                }
            }

            /// <summary>
            /// Gets the linked list.
            /// </summary>
            /// <param name="position">The position.</param>
            /// <returns></returns>
            /// <remarks></remarks>
            protected LinkedList<KeyValue<K, V>> GetLinkedList(int position)
            {
                LinkedList<KeyValue<K, V>> linkedList = items[position];
                if (linkedList == null)
                {
                    linkedList = new LinkedList<KeyValue<K, V>>();
                    items[position] = linkedList;
                }

                return linkedList;
            }
        }
    }
}