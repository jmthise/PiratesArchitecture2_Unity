using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Unity.Netcode;

public class NetworkMenu : VisualElement {
    private VisualElement Pannel_Ingame;
    private VisualElement Pannel_Lobby;
    private Button StartHostButton;
    private Button StartClientButton;
    private Button StartServerButton;
    private Button DisconnectButton;
    public NetworkMenu() {
        Build();
        NetworkManager.Singleton.OnClientStarted += OnClientStarted;
        NetworkManager.Singleton.OnClientStopped += OnClientStopped;
        NetworkManager.Singleton.OnServerStarted += OnServerStarted;
        NetworkManager.Singleton.OnServerStopped += OnServerStopped;
        StartHostButton.clicked += OnStartHostButtonClicked;
        StartClientButton.clicked += OnStartClientButtonClicked;
        StartServerButton.clicked += OnStartServerButtonClicked;
        DisconnectButton.clicked += OnDisconnectButtonClicked;
    }
    private void Build() {
        Pannel_Lobby = new VisualElement();
        Add(Pannel_Lobby);
        StartHostButton = new Button() { text = "Host" };
        StartClientButton = new Button() { text = "Client" };
        StartServerButton = new Button() { text = "Server" };
        Pannel_Lobby.Add(StartHostButton);
        Pannel_Lobby.Add(StartClientButton);
        Pannel_Lobby.Add(StartServerButton);
        Pannel_Ingame = new VisualElement();
        Add(Pannel_Ingame);
        DisconnectButton = new Button() { text = "Disconnect" };
        Pannel_Ingame.Add(DisconnectButton);
    }
    private void ToIngamePannel() {
        Pannel_Ingame.style.display = DisplayStyle.Flex;
        Pannel_Lobby.style.display = DisplayStyle.None;
    }
    private void ToLobbyPannel() {
        Pannel_Ingame.style.display = DisplayStyle.None;
        Pannel_Lobby.style.display = DisplayStyle.Flex;
    }
    private void OnClientStarted() => ToIngamePannel();
    private void OnClientStopped(bool b) => ToLobbyPannel();
    private void OnServerStarted() => ToIngamePannel();
    private void OnServerStopped(bool b) => ToLobbyPannel();
    void OnStartHostButtonClicked() { NetworkManager.Singleton.StartHost(); }
    void OnStartClientButtonClicked() { NetworkManager.Singleton.StartClient(); }
    void OnStartServerButtonClicked() { NetworkManager.Singleton.StartServer(); }
    void OnDisconnectButtonClicked() { NetworkManager.Singleton.Shutdown(); }
}