def LCS(n, m):
    ret = 0
    if len(n) == 0 or len(m) == 0:
        return ret

    while True:
        if n[0] == m[0]:
            ret = 1 + LCS(n[1:], m[1:])
        else:
            i = 0
            while True:
                ret = LCS(n[1:], m[i:])
                if ret == 0:
                    return ret
                i = i + 1

        return ret

def answer():
    print(LCS('AGGTAB','GXTXAYB'))


answer()