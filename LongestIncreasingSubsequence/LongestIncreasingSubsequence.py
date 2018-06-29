def LIS():
    numbers = [3, 2, 6, 4, 5, 1]
    
    L = []
    L.extend([1]*len(numbers))

    L[0] = numbers[0]
    for i in range(1, len(numbers)- 1):
        for j in range(i - 1):
            if numbers[j] < numbers[i] and L[i] < L[j] + 1:
                L[i] = L[j]
        L[i] = numbers[i]

    return max(L)
     



g = LIS()
p = g