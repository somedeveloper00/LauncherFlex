using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEngine;

namespace LauncherFlex
{
    public class Manager : MonoBehaviour
    {
        [SerializeField] private GameView _gameViewPrefab;
        [SerializeField] private Transform _gameViewParent;

        private List<GameData> _datas;
        private List<GameView> gameViews = new List<GameView>();

        private List<CancellationTokenSource> _currentCancelTokens = new List<CancellationTokenSource>();

        private void Start()
        {
            LoadGameData();
        }

        private void OnDestroy()
        {
            foreach (var source in _currentCancelTokens) source?.Cancel();
        }

        private void LoadGameData()
        {
            if (File.Exists(IOUtils.DATA_SAVE_PATH))
            {
                IOUtils.LoadGameData(
                    (gameDats) =>
                    {
                        if (gameDats == null)
                        {
                            Debug.LogWarning($"Data not readable");
                            return;
                        }

                        _datas = gameDats;

                        // instantiate views
                        foreach (var gameData in _datas)
                        {
                            var gameView = Instantiate(_gameViewPrefab, _gameViewParent);
                            gameView.Init(gameData);
                            gameViews.Add(gameView);
                        }
                    },
                    () =>
                    {
                        
                    });
            }
        }
    }
}