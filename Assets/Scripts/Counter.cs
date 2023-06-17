using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Счетчики для отображения уровня и очков на экране
 */
public static class Counter
{
    public const int firstLevel = 1;
    public const int startScore = 0;

    public static int level = firstLevel;
    public static int score = startScore;
}
