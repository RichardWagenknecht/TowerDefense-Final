using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager main; // Inst�ncia �nica do GerenciadorJogo

    [Header("Configura��es de Spawn de Inimigos")]
    [SerializeField] List<GameObject> prefabInimigo; // Lista de prefabs de inimigos
    [SerializeField] int inimigosBase = 8; // N�mero base de inimigos por onda
    [SerializeField] float inimigosPorSegundo = 0.5f; // Taxa de spawn de inimigos
    [SerializeField] float tempoEntreOndas = 5f; // Tempo entre ondas de inimigos
    [SerializeField] float dificuldadeEscalonamento = 0.75f; // Escalonamento da dificuldade

    [Header("Configura��es de Pontos")]
    public Transform pontoInicial; // Ponto de spawn inicial dos inimigos
    public Transform[] pontos; // Array de pontos de spawn

    [Header("Configura��es de Moeda")]
    public int currency = 100; // Quantidade inicial de moedas

    int ondaAtual = 1; // Onda atual de inimigos
    float tempoDesdeUltimoSpawn; // Tempo desde o �ltimo spawn de inimigos
    int inimigosVivos; // N�mero de inimigos vivos
    int inimigosRestantesParaSpawn; // Inimigos restantes para spawnar
    bool isSpawning = false; // Estado do spawn

    public static UnityEvent onEnemyDestroy = new UnityEvent(); // Evento acionado ao destruir um inimigo
    private List<GameObject> inimigosAtivos = new List<GameObject>(); // Lista para armazenar inimigos ativos

    
}
