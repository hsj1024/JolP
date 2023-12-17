using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �ø�������� ������ ���׸� ��ųʸ� Ŭ����
[System.Serializable]
public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
{
    [SerializeField]
    private List<TKey> keys = new List<TKey>(); // ��ųʸ� Ű�� �����ϴ� ����Ʈ

    [SerializeField]
    private List<TValue> values = new List<TValue>(); // ��ųʸ� ������ �����ϴ� ����Ʈ

    // ��ųʸ��� ����Ʈ�� ��ȯ�Ͽ� ����ȭ ������ ȣ���
    public void OnBeforeSerialize()
    {
        keys.Clear();
        values.Clear();
        foreach (KeyValuePair<TKey, TValue> pair in this)
        {
            keys.Add(pair.Key);
            values.Add(pair.Value);
        }
    }

    // ����Ʈ�κ��� ��ųʸ��� �����Ͽ� ������ȭ ���Ŀ� ȣ���
    public void OnAfterDeserialize()
    {
        this.Clear();

        // Ű�� ���� ������ ��ġ���� ������ ���� �߻�
        if (keys.Count != values.Count)
            throw new Exception("There are " + keys.Count + " keys and " + values.Count + " values after deserialization. Make sure that both key and value types are serializable.");

        // ����Ʈ���� ��ųʸ��� ������ ����
        for (int i = 0; i < keys.Count; i++)
            this.Add(keys[i], values[i]);
    }
}
