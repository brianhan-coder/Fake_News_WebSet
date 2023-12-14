def main(arr):
    try:
        arr = set(arr)
        arr = sorted(arr)
        arr = arr[0:]
        return str(arr)
    except Exception as err:
        return str(err)