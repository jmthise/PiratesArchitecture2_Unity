using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Unity.Netcode;

public class NetworkMenu : VisualElement {
    bool connected = false;
    VisualElement Pannel_Disconnected;
    VisualElement btn_host;
    VisualElement btn_client;
    VisualElement btn_server;
    VisualElement Pannel_Connected;
    VisualElement btn_disconnect;
    public NetworkMenu() {
        Pannel_Disconnected = new VisualElement();
        Add(Pannel_Disconnected);

        btn_host = new Button() { text = "Host" };
        btn_client = new Button() { text = "Client" };
        btn_server = new Button() { text = "Server" };
        Pannel_Disconnected.Add(btn_host);
        Pannel_Disconnected.Add(btn_client);
        Pannel_Disconnected.Add(btn_server);

        btn_host.RegisterCallback<MouseUpEvent>(ev => OnHostClicked());
        btn_client.RegisterCallback<MouseUpEvent>(ev => OnClientClicked());
        btn_server.RegisterCallback<MouseUpEvent>(ev => OnServerClicked());

        Pannel_Connected = new VisualElement();
        Add(Pannel_Connected);

        btn_disconnect = new Button() { text = "Disconnect" };
        Pannel_Connected.Add(btn_disconnect);

        btn_disconnect.RegisterCallback<MouseUpEvent>(ev => OnDisconnectClicked());
        ToDisconnected();
    }
    void ToConnected() {
        Pannel_Disconnected.style.display = DisplayStyle.None;
        Pannel_Connected.style.display = DisplayStyle.Flex;
    }
    void ToDisconnected() {
        Pannel_Disconnected.style.display = DisplayStyle.Flex;
        Pannel_Connected.style.display = DisplayStyle.None;
    }
    void OnHostClicked() => NetworkManager.Singleton.StartHost();
    void OnClientClicked() => NetworkManager.Singleton.StartClient();
    void OnServerClicked() => NetworkManager.Singleton.StartServer();
    void OnDisconnectClicked() { }
}