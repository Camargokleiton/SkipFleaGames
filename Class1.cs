using BepInEx;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

[BepInPlugin("skip.fleagames", "Skip Flea Games", "1.0.0")]
public class SkipFleaGames : BaseUnityPlugin
{
    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        Logger.LogInfo("Skip Flea Games carregado");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name.Contains("Menu"))
            return;

        StartCoroutine(ApplySkip());
    }

    private IEnumerator ApplySkip()
    {
        yield return new WaitForSeconds(1.5f);

        var gm = GameManager.instance;
        if (gm == null || gm.playerData == null)
            yield break;

        var pd = gm.playerData;

        pd.SetInt("fleaGames_juggling_highscore", 120);
        pd.SetInt("fleaGames_dodging_highscore", 120);
        pd.SetInt("fleaGames_bouncing_highscore", 120);

        pd.SetBool("fleaGames_juggling_played", true);
        pd.SetBool("fleaGames_dodging_played", true);
        pd.SetBool("fleaGames_bouncing_played", true);

        Logger.LogInfo("Minigames das pulgas ignorados com sucesso");
    }
}
