from abc import ABC, abstractmethod


class IPrinter(ABC):
    @abstractmethod
    def print(self):
        pass


class IScanner(ABC):
    @abstractmethod
    def scan(self):
        pass


class Printer(IPrinter):
    def print(self):
        print("Printing document...")


class Scanner(IScanner):
    def scan(self):
        print("Scanning document...")


class PrintScanner(IPrinter, IScanner):
    def print(self):
        print("PrintScanner: Printing document...")

    def scan(self):
        print("PrintScanner: Scanning document...")


class TaskManager:
    def print_task(self, task_id, printer: IPrinter):
        print(f"Executing Print Task: {task_id}")
        printer.print()

    def scan_task(self, task_id, scanner: IScanner):
        print(f"Executing Scan Task: {task_id}")
        scanner.scan()


printer = Printer()
scanner = Scanner()
printScanner = PrintScanner()

scheduler = TaskManager()

scheduler.print_task(101, printer)
scheduler.scan_task(102, scanner)

scheduler.print_task(103, printScanner)
scheduler.scan_task(104, printScanner)